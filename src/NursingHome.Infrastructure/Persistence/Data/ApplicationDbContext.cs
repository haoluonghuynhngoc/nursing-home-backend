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
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDate> OrderDates { get; set; }
    public DbSet<ServicePackage> ServicePackages { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<ServicePackageCategory> ServicePackageCategories { get; set; }
    public DbSet<ServicePackageDate> ServicePackageDates { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<CareSchedule> CareSchedules { get; set; }
    public DbSet<NursingPackage> NursingPackages { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<ScheduledService> ScheduledServices { get; set; }
    public DbSet<ScheduledServiceDetail> ScheduledServiceDetails { get; set; }
    public DbSet<ScheduledTime> ScheduledTimes { get; set; }
    public DbSet<PotentialCustomer> PotentialCustomers { get; set; }
    public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
    public DbSet<MonthlyCalendar> MonthlyCalendars { get; set; }
    public DbSet<MonthlyCalendarDetail> MonthlyCalendarDetails { get; set; }
    public DbSet<EmployeeType> EmployeeTypes { get; set; }
    public DbSet<FamilyMember> FamilyMembers { get; set; }
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

        //modelBuilder.Entity<UserNurseSchedule>()
        //    .HasKey(uns => new { uns.UserId, uns.NurseScheduleId });

        //modelBuilder.Entity<UserNurseSchedule>()
        //    .HasOne(uns => uns.User)
        //    .WithMany(u => u.UserNurseSchedules)
        //    .HasForeignKey(uns => uns.UserId);

        //modelBuilder.Entity<UserNurseSchedule>()
        //    .HasOne(uns => uns.NurseSchedule)
        //    .WithMany(ns => ns.UserNurseSchedules)
        //    .HasForeignKey(uns => uns.NurseScheduleId);
    }
}

