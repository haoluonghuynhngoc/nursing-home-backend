using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Domain.Constants;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
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
        if (!await unitOfWork.Repository<Block>().ExistsByAsync())
        {
            foreach (var item in BlockSeed.Default)
            {
                await unitOfWork.Repository<Block>().CreateAsync(item);
            }
            await unitOfWork.CommitAsync();
        }
        if (!await unitOfWork.Repository<HealthCategory>().ExistsByAsync())
        {
            foreach (var item in HealthCaterorySeed.Default)
            {
                await unitOfWork.Repository<HealthCategory>().CreateAsync(item);
            }
            await unitOfWork.CommitAsync();
        }
        if (!await unitOfWork.Repository<NursingPackage>().ExistsByAsync())
        {
            foreach (var item in NursingPackageSeed.DefaultNursingPackage)
            {
                await unitOfWork.Repository<NursingPackage>().CreateAsync(item);
            }
            await unitOfWork.CommitAsync();
        }
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
                AvatarUrl = "https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg",
                FullName = "Admin",
                Address = "Hanoi",
                CCCD = "123456789",
                DateOfBirth = "01/01/1990",
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "admin");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Admin });

            user = new User
            {
                UserName = "user",
                IsActive = true,
                AvatarUrl = "https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg",
                FullName = "user",
                Address = "Ho Chi Minh",
                CCCD = "123456789",
                DateOfBirth = "01/01/1999",
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "user");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Customer });

            user = new User
            {
                UserName = "director",
                IsActive = true,
                AvatarUrl = "https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg",
                FullName = "Director",
                Address = "Da Nang",
                CCCD = "123456789",
                DateOfBirth = "01/01/1999",
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "director");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Director });

            user = new User
            {
                UserName = "manager",
                IsActive = true,
                AvatarUrl = "https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg",
                FullName = "Manager",
                Address = "Long An",
                CCCD = "123456789",
                DateOfBirth = "01/01/1990",
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "manager");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Manager });

            user = new User
            {
                UserName = "staff",
                IsActive = true,
                AvatarUrl = "https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg",
                FullName = "Staff",
                Address = "Da Lat",
                CCCD = "123456789",
                DateOfBirth = "01/01/1990",
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "staff");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Staff });

            user = new User
            {
                UserName = "nurses",
                IsActive = true,
                AvatarUrl = "https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg",
                FullName = "Nurses",
                Address = "Ca Mau",
                CCCD = "123456789",
                DateOfBirth = "01/01/1990",
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "nurses");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Nurse });
        }

    }
}
