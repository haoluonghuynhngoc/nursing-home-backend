using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class PackageTypeSeed
{
    public static List<PackageCategory> Default =>
     new List<PackageCategory>
     {
            new PackageCategory { Name = PackageCategoryName.ServicePackage },
            new PackageCategory { Name = PackageCategoryName.RegisterPackage }
     };
}
