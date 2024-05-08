using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using System.Reflection;

namespace NursingHome.Infrastructure.Persistence.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
{
    private const string Prefix = "AspNet";

    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Device> Devices { get; set; }

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
    }
}
