using NursingHome.Domain.Entities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class ServicePackageCategorySeed
{
    public static List<ServicePackageCategory> Default =>
         new List<ServicePackageCategory>
         {
            new ServicePackageCategory {
               Name = "Health and Wellness Package",
            },
            new ServicePackageCategory {
               Name = "Holiday Special" ,
            },
            new ServicePackageCategory {
               Name = "Eco-Friendly Package",
            },
            new ServicePackageCategory {
               Name = "Weekend Special",
            },
            new ServicePackageCategory {
               Name = "Fitness Plus",
            },
         };
}
