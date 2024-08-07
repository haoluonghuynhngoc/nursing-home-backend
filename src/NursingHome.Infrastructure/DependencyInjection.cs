﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NursingHome.Application.Contracts.Jobs;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Contracts.Services.Payments;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Infrastructure.Jobs;
using NursingHome.Infrastructure.Persistence.Data;
using NursingHome.Infrastructure.Persistence.Interceptors;
using NursingHome.Infrastructure.Persistence.SeedData;
using NursingHome.Infrastructure.Repositories;
using NursingHome.Infrastructure.Services;
using NursingHome.Infrastructure.Services.Notifications;
using NursingHome.Infrastructure.Services.Payments;
using NursingHome.Infrastructure.Settings;

namespace NursingHome.Infrastructure;
public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddServices();
        services.AddDbContext(configuration);
        services.AddRepositories();
        services.AddInitialiseDatabase();
        services.AddDefaultIdentity();
        services.AddConfigureSettingServices(configuration);

    }

    private static void AddServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ICacheService, CacheService>()
            .AddScoped<ICurrentUserService, CurrentUserService>()
            .AddScoped<IStorageService, StorageService>()
            .AddScoped<IJwtService, JwtService>()
            .AddScoped<IMomoPaymentService, MomoPaymentService>()
            .AddScoped<IVnPayPaymentService, VnPayPaymentService>()
            .AddScoped<INotifier, Notifier>()
            .AddScoped<INotificationProvider, NotificationProvider>()
            .AddScoped<ISignalRNotificationService, SignalRNotificationService>()
            .AddScoped<IFirebaseNotificationService, FirebaseNotificationService>()
            .AddScoped<ISmsNotificationService, SmsNotificationService>()
            .AddScoped<IExpoNotificationService, ExpoNotificationService>()
            .AddTransient<IEmailSender, EmailSender>()
            .AddTransient<ISmsSender, SmsSender>()
            .AddSingleton<ITimeService, TimeService>()
            .AddTransient<ITaskSchedulerOrder, TaskSchedulerOrder>();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        string defaultConnection = configuration.GetConnectionString("DefaultConnection")!;
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
           options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection),
               builder =>
               {
                   builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                   builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
               })
                  .AddInterceptors(sp.GetServices<ISaveChangesInterceptor>())
                  .EnableSensitiveDataLogging()
                  .EnableDetailedErrors()
                  .UseProjectables());

    }

    private static void AddDefaultIdentity(this IServiceCollection services)
    {

        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 1;
            options.Password.RequiredUniqueChars = 0;
            //options.User.RequireUniqueEmail = true;

            // Lockout configuration
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Lockout time of 5 minutes
            options.Lockout.MaxFailedAccessAttempts = 5; // Lockout after 5 failed attempts
            options.Lockout.AllowedForNewUsers = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();
    }

    private static void AddConfigureSettingServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AwsS3Settings>(configuration.GetSection(AwsS3Settings.Section));
        services.Configure<VnPaySettings>(configuration.GetSection(VnPaySettings.Section));
        services.Configure<MomoSettings>(configuration.GetSection(MomoSettings.Section));
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));
        services.Configure<FcmSettings>(configuration.GetSection(FcmSettings.Section));
        services.Configure<MailSettings>(configuration.GetSection(MailSettings.Section));
        services.Configure<SmsGatewaySettings>(configuration.GetSection(SmsGatewaySettings.Section));
        services.Configure<SpeedSmsSettings>(configuration.GetSection(SpeedSmsSettings.Section));
    }

    private static void AddInitialiseDatabase(this IServiceCollection services)
    {
        services
            .AddScoped<ApplicationDbContextInitialiser>();
    }

    public static async Task UseInitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        if (app.Environment.IsDevelopment())
        {
            //await initialiser.DeletedDatabaseAsync();
            await initialiser.MigrateAsync();
            await initialiser.SeedAsync();
        }

        if (app.Environment.IsProduction())
        {
            await initialiser.MigrateAsync();
            await initialiser.SeedAsync();
        }
    }
}
