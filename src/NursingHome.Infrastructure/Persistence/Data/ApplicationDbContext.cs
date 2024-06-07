using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using System.Reflection;

namespace NursingHome.Infrastructure.Persistence.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
//public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{

    private const string Prefix = "AspNet";
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Block> Blocks { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Elder> Elders { get; set; }
    public DbSet<FeedBack> Feedbacks { get; set; }
    public DbSet<HealthCategory> HealthCategories { get; set; }
    public DbSet<HealthReport> HealthReports { get; set; }
    public DbSet<HealthReportDetail> HealthReportDetails { get; set; }
    public DbSet<HealthReportDetailMeasure> HealthReportDetailMeasures { get; set; }
    public DbSet<MeasureUnit> MeasureUnits { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NursingPackage> NursingPackages { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDate> OrderDates { get; set; }
    public DbSet<ServicePackage> ServicePackages { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<ServicePackageCategory> ServicePackageCategories { get; set; }
    public DbSet<ServicePackageDate> ServicePackageDates { get; set; }

    // Join Tables
    public DbSet<NursingPackageUser> NursingPackageUsers { get; set; }
    public DbSet<ServicePackageUser> ServicePackageUsers { get; set; }
    public DbSet<ElderNursingPackage> ElderNursingPackages { get; set; }
    public DbSet<ElderServicePackage> ElderServicePackages { get; set; }

    //public ApplicationDbContext()
    //{
    //}

    ////dotnet ef migrations add CreateInit --output-dir Persistence/Migrations
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    // Mysql In Digital Ocean
    //    // ssh -i capstone -L 3307:localhost:3306 root@142.93.222.144
    //    //optionsBuilder.UseMySQL("server=localhost;port=3307;user=root;password=root;database=NursingHome");
    //    // Mysql In Local
    //    optionsBuilder.UseMySQL("server=localhost;user=root;password=root;database=NursingHome");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName != null && tableName.StartsWith(Prefix))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        modelBuilder.Entity<UserRole>(b =>
        {
            b.HasOne(e => e.Role)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            b.HasOne(e => e.User)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(ur => ur.UserId);
        });
        modelBuilder.Entity<NursingPackageUser>(_ =>
        {
            _.HasKey(a => new { a.UserId, a.NursingPackageId });
            _.HasOne(e => e.User)
                .WithMany(e => e.NursingPackageUsers)
                .HasForeignKey(ur => ur.UserId);

            _.HasOne(e => e.NursingPackage)
                .WithMany(e => e.NursingPackageUsers)
                .HasForeignKey(ur => ur.NursingPackageId);
        });
        modelBuilder.Entity<ServicePackageUser>(_ =>
        {
            _.HasKey(a => new { a.UserId, a.ServicePackageId });
            _.HasOne(e => e.User)
                .WithMany(e => e.ServicePackageUsers)
                .HasForeignKey(ur => ur.UserId);

            _.HasOne(e => e.ServicePackage)
                .WithMany(e => e.ServicePackageUsers)
                .HasForeignKey(ur => ur.ServicePackageId);
        });
        modelBuilder.Entity<ElderNursingPackage>(_ =>
        {
            _.HasKey(a => new { a.ElderId, a.NursingPackageId });
            _.HasOne(e => e.Elder)
                .WithMany(e => e.ElderNursingPackages)
                .HasForeignKey(ur => ur.ElderId);

            _.HasOne(e => e.NursingPackage)
                .WithMany(e => e.ElderNursingPackages)
                .HasForeignKey(ur => ur.NursingPackageId);
        });
        modelBuilder.Entity<ElderServicePackage>(_ =>
        {
            _.HasKey(a => new { a.ElderId, a.ServicePackageId });
            _.HasOne(e => e.Elder)
                .WithMany(e => e.ElderServicePackages)
                .HasForeignKey(ur => ur.ElderId);

            _.HasOne(e => e.ServicePackage)
                .WithMany(e => e.ElderServicePackages)
                .HasForeignKey(ur => ur.ServicePackageId);
        });
    }
}
