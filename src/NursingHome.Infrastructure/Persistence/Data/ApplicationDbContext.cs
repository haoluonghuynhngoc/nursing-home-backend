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

    //public ApplicationDbContext()
    //{
    //}

    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentType> AppointmentTypes { get; set; }
    public DbSet<Block> Blocks { get; set; }
    public DbSet<Bed> Beds { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<BillDetail> BillDetails { get; set; }
    public DbSet<CareSchedule> CareSchedules { get; set; }
    public DbSet<CareScheduleTask> CareScheduleTasks { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Elder> Elders { get; set; }
    public DbSet<FeedBack> FeedBacks { get; set; }
    public DbSet<HealthReport> HealthReports { get; set; }
    public DbSet<HealthReportCategory> HealthReportCategories { get; set; }
    public DbSet<HealthReportDetail> HealthReportDetails { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<PackageType> PackageTypes { get; set; }
    public DbSet<Payment> Payments { get; set; }

    // join Table HealthReportDetail

    public DbSet<AppointmentUser> AppointmentUsers { get; set; }
    public DbSet<ElderPackage> ElderPackages { get; set; }
    public DbSet<ElderUser> ElderUsers { get; set; }
    public DbSet<UserCareSchedule> UserCareSchedules { get; set; }

    // dotnet ef migrations add CreateInit --output-dir Persistence/Migrations
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

        //modelBuilder.Entity<Bed>()
        //    .Property(e => e.Id)
        //    .ValueGeneratedOnAdd()
        //    .UseMySqlIdentityColumn();
        //modelBuilder.Entity<Room>()
        //    .Property(e => e.Id)
        //    .ValueGeneratedOnAdd()
        //    .UseMySqlIdentityColumn();
        //modelBuilder.Entity<CareScheduleTask>()
        //    .Property(e => e.Id)
        //    .ValueGeneratedOnAdd()
        //    .UseMySqlIdentityColumn();
        //modelBuilder.Entity<PackageType>()
        //    .Property(e => e.Id)
        //    .ValueGeneratedOnAdd()
        //    .UseMySqlIdentityColumn();
        //modelBuilder.Entity<HealthReportCategory>()
        //    .Property(e => e.Id)
        //    .ValueGeneratedOnAdd()
        //    .UseMySqlIdentityColumn();
        //modelBuilder.Entity<AppointmentType>()
        //    .Property(e => e.Id)
        //    .ValueGeneratedOnAdd()
        //    .UseMySqlIdentityColumn();

        //modelBuilder.Entity<UsersRole>(entity =>
        //{
        //    entity.HasKey(ur => new { ur.RoleId, ur.UsersId });
        //});

        modelBuilder.Entity<UserRole>(b =>
        {

            b.HasOne(e => e.Role)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            b.HasOne(e => e.User)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(ur => ur.UserId);
        });
        modelBuilder.Entity<AppointmentUser>(entity =>
        {
            entity.HasKey(a => new { a.AppointmentId, a.UserId });
            entity.HasOne(a => a.Appointment)
             .WithMany(a => a.AppointmentUsers)
             .HasForeignKey(a => a.AppointmentId);

            entity.HasOne(a => a.User)
             .WithMany(a => a.AppointmentUsers)
             .HasForeignKey(a => a.UserId);
        });
        modelBuilder.Entity<ElderPackage>(entity =>
        {
            entity.HasKey(a => new { a.ElderId, a.PackageId });
            entity.HasOne(a => a.Elder)
             .WithMany(a => a.ElderPackages)
             .HasForeignKey(a => a.ElderId);

            entity.HasOne(a => a.Package)
             .WithMany(a => a.ElderPackages)
             .HasForeignKey(a => a.PackageId);
        });
        modelBuilder.Entity<ElderUser>(entity =>
        {
            entity.HasKey(a => new { a.ElderId, a.UserId });
            entity.HasOne(a => a.Elder)
             .WithMany(a => a.ElderUsers)
             .HasForeignKey(a => a.ElderId);

            entity.HasOne(a => a.User)
             .WithMany(a => a.ElderUsers)
             .HasForeignKey(a => a.UserId);
        });
        modelBuilder.Entity<UserCareSchedule>(entity =>
        {
            entity.HasKey(a => new { a.UserId, a.CareScheduleId });
            entity.HasOne(a => a.User)
             .WithMany(a => a.UserCareSchedules)
             .HasForeignKey(a => a.UserId);

            entity.HasOne(a => a.CareSchedule)
             .WithMany(a => a.UserCareSchedules)
             .HasForeignKey(a => a.CareScheduleId);
        });
    }
}
