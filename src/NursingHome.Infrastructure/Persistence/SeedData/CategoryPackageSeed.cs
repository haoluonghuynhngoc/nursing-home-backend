using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal class CategoryPackageSeed
{
    public static List<PackageCategory> Default =>
    new List<PackageCategory>
    {
            new PackageCategory { Name = PackageCategoryName.ServicePackage },
            new PackageCategory { Name = PackageCategoryName.RegisterPackage }
    };
}
