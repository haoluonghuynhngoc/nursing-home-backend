using NursingHome.Domain.Entities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class ServicePackageCategorySeed
{
    public static List<ServicePackageCategory> Default =>
         new List<ServicePackageCategory>
         {
            new ServicePackageCategory {
               Name = "Gói Sức Khỏe và Thể Chất",
            },
            new ServicePackageCategory {
               Name = "Ưu Đãi Dịp Lễ" ,
            },
            new ServicePackageCategory {
               Name = "Gói Thân Thiện Với Môi Trường",
            },
            new ServicePackageCategory {
               Name = "Ưu Đãi Cuối Tuần",
            },
            new ServicePackageCategory {
               Name = "Gói Thể Dục Thể Thao",
            },
         };
}
