using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Infrastructure.Persistence.Data;

namespace NursingHome.Infrastructure.Persistence.SeedData;

public class ApplicationDbContextInitialiser(
   ILogger<ApplicationDbContextInitialiser> logger,
   ApplicationDbContext context,
   UserManager<User> userManager,
   RoleManager<Role> roleManager,
   IUnitOfWork unitOfWork)
{
    public async Task MigrateAsync()
    {
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task DeletedDatabaseAsync()
    {
        try
        {
            await context.Database.EnsureDeletedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {

        if (!await unitOfWork.Repository<Role>().ExistsByAsync())
        {
            foreach (var item in RoleSeed.Default)
            {
                await roleManager.CreateAsync(item);
            }
        }

        if (!await unitOfWork.Repository<User>().ExistsByAsync())
        {
            var user = new User
            {
                UserName = "admin",
                IsActive = true,
            };
            await userManager.CreateAsync(user, "admin");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Admin });

            user = new User
            {
                UserName = "user",
                IsActive = true,
            };
            await userManager.CreateAsync(user, "user");
            await userManager.AddToRolesAsync(user, new[] { RoleName.User });

            user = new User
            {
                UserName = "director",
                IsActive = true,
            };
            await userManager.CreateAsync(user, "director");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Director });

            user = new User
            {
                UserName = "manager",
                IsActive = true,
            };
            await userManager.CreateAsync(user, "manager");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Manager });

            user = new User
            {
                UserName = "staff",
                IsActive = true,
            };
            await userManager.CreateAsync(user, "staff");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Staff });

            user = new User
            {
                UserName = "nurses",
                IsActive = true,
            };
            await userManager.CreateAsync(user, "nurses");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Nurses });
        }

    }
}
