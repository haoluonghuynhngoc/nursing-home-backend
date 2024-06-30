using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NursingHome.Application.Behaviours;
using NursingHome.Application.TaskSchedulers;
using NursingHome.Application.TaskSchedulers.Impl;
using NursingHome.Shared.Helpers;
using System.Reflection;

namespace NursingHome.Application;
public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidators();
        services.AddMediator();
        services.AddCachingRedis(configuration);
        services.AddHangFireServices();
    }

    private static void AddHangFireServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ITimeService, TimeService>()
            .AddTransient<ITaskSchedulerOrder, TaskSchedulerOrder>();
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        });
    }
    private static void AddCachingRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            string cacheConnection = configuration.GetConnectionString("CacheConnection")!;
            options.Configuration = cacheConnection;

        });
        services.AddMemoryCache();
    }
    private static void AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationRulesToSwagger();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        ValidatorOptions.Global.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;
        services.AddFluentValidationAutoValidation();
    }
}
