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
            var block = BlockSeed.Default;
            foreach (var itemBlock in block)
            {
                var room = BlockSeed.DefaultRoom;
                foreach (var itemRoom in room)
                {
                    itemBlock.Rooms.Add(itemRoom);
                }
                await unitOfWork.Repository<Block>().CreateAsync(itemBlock);
            }
            await unitOfWork.CommitAsync();
        }

        if (!await unitOfWork.Repository<HealthReportCategory>().ExistsByAsync())
        {
            foreach (var item in HealthCaterorySeed.Default)
            {
                await unitOfWork.Repository<HealthReportCategory>().CreateAsync(item);
            }
            await unitOfWork.CommitAsync();
        }

        if (!await unitOfWork.Repository<PackageType>().ExistsByAsync())
        {
            foreach (var item in PackageTypeSeed.Default)
            {
                await unitOfWork.Repository<PackageType>().CreateAsync(item);
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

        if (!await unitOfWork.Repository<PackageServiceType>().ExistsByAsync())
        {
            var listPackageType = new List<PackageServiceType>() {
            new PackageServiceType { Name = "Service 1" },
            new PackageServiceType { Name = "Service 2" },
            new PackageServiceType { Name = "Service 3" },
            new PackageServiceType { Name = "Service 4" },
            new PackageServiceType { Name = "Service 5" }
            };
            foreach (var item in listPackageType)
            {
                await unitOfWork.Repository<PackageServiceType>().CreateAsync(item);
            }
            await unitOfWork.CommitAsync();
        }

        if (await unitOfWork.Repository<PackageType>().ExistsByAsync())
        {
            if (!await unitOfWork.Repository<Package>().ExistsByAsync())
            {
                var packageType = await unitOfWork.Repository<PackageType>().FindByAsync(_ => _.Name == PackageTypeName.RegisterPackage);
                foreach (var item in ElderSeed.DefaultPackage)
                {
                    if (packageType != null)
                    {
                        item.PackageType = packageType;
                    }
                    await unitOfWork.Repository<Package>().CreateAsync(item);
                }
            }
        }
        if (await unitOfWork.Repository<Package>().ExistsByAsync())
        {
            if (await unitOfWork.Repository<Room>().ExistsByAsync())
            {
                var packageRegister = await unitOfWork.Repository<Package>().Entities.FirstOrDefaultAsync();
                var listRoom = await unitOfWork.Repository<Room>().Entities.ToListAsync();
                if (packageRegister != null)
                {
                    foreach (var item in listRoom)
                    {
                        item.Package = packageRegister;
                    }
                }
            }
        }
        if (!await unitOfWork.Repository<Elder>().ExistsByAsync())
        {
            if (await unitOfWork.Repository<Room>().ExistsByAsync())
            {
                var elders = ElderSeed.Default.ToList();
                var listRoom = await unitOfWork.Repository<Room>().Entities.ToListAsync();

                for (int i = 0; i < listRoom.Count && i < elders.Count; i++)
                {
                    var room = listRoom[i];
                    var elder = elders[i];

                    elder.Room = room;
                    await unitOfWork.Repository<Elder>().CreateAsync(elder);
                }
            }
        }

        if (!await unitOfWork.Repository<User>().ExistsByAsync())
        {
            var user = new User
            {
                UserName = "admin",
                IsActive = true,
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "admin");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Admin });

            user = new User
            {
                UserName = "user",
                IsActive = true,
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "user");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Customer });

            user = new User
            {
                UserName = "director",
                IsActive = true,
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "director");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Director });

            user = new User
            {
                UserName = "manager",
                IsActive = true,
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "manager");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Manager });

            user = new User
            {
                UserName = "staff",
                IsActive = true,
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "staff");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Staff });

            user = new User
            {
                UserName = "nurses",
                IsActive = true,
                Gender = GenderStatus.Male,
            };
            await userManager.CreateAsync(user, "nurses");
            await userManager.AddToRolesAsync(user, new[] { RoleName.Nurse });
        }

    }
}
