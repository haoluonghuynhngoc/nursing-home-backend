using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

    }
}
