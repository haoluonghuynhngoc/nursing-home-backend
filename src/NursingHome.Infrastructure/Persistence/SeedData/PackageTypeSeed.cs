using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class PackageTypeSeed
{
    public static List<PackageType> Default =>
     new List<PackageType>
     {
            new PackageType { Name = PackageTypeName.ServicePackage },
            new PackageType { Name = PackageTypeName.RegisterPackage }
     };
}
