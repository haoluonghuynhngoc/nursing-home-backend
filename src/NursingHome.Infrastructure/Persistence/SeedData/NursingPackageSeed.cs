//using Bogus;
//using NursingHome.Domain.Entities;
//using NursingHome.Domain.Enums;

using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class NursingPackageSeed
{
    //public static List<NursingPackage> DefaultNursingPackage =>
    //    new Faker<NursingPackage>()
    //        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
    //        .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
    //        .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl())
    //        .RuleFor(p => p.Type, f => f.PickRandom<NursingPackageType>())
    //        .RuleFor(p => p.Price, f => f.Finance.Amount())
    //        .RuleFor(p => p.RegistrationLimit, f => f.Random.Int(100, 1000))
    //        .RuleFor(p => p.Capacity, f => f.Random.Int(1, 10))
    //        .RuleFor(p => p.State, f => f.PickRandom<StateType>())
    //        .RuleFor(p => p.NumberOfNurses, f => f.Random.Int(1, 10))
    //        .Generate(9);
    public static List<NursingPackage> DefaultNursingPackage =>
        new List<NursingPackage>
        {
            new NursingPackage
            {
                Name = "Gói Chăm Sóc Cao Cấp",
                Description = "Gói dịch vụ chăm sóc sức khỏe và thể chất",
                Type = NursingPackageType.Normal,
                State = StateType.Active,
                Price = 1000000,
                RegistrationLimit = 100,
                ImageUrl = "https://image.sggp.org.vn/w1000/Uploaded/2024/evofjasfzyr/2022_11_21/23_ODZC.jpg.webp",
                NumberOfNurses = 1,
                Capacity = 10
            },
            new NursingPackage
            {
                Name = "Gói Khuyến Mãi Dịp Lễ",
                Description = "Gói dịch vụ ưu đãi dịp lễ",
                Type = NursingPackageType.Special,
                State = StateType.Active,
                Price = 1500000,
                RegistrationLimit = 150,
                ImageUrl = "https://nhaduonglao.com/wp-content/uploads/2023/11/Vien-duong-lao-Nghe-Si.jpg",
                NumberOfNurses = 2,
                Capacity = 15
            },
            new NursingPackage
            {
                Name = "Gói Xanh Sạch",
                Description = "Gói dịch vụ thân thiện với môi trường",
                Type = NursingPackageType.Vip,
                State = StateType.Active,
                Price = 2000000,
                RegistrationLimit = 200,
                ImageUrl = "https://vienduonglaonhanai.vn/wp-content/uploads/2024/02/425499524_1129059848367861_4681676633479513605_n.jpg",
                NumberOfNurses = 3,
                Capacity = 20
            },
            new NursingPackage
            {
                Name = "Gói Cuối Tuần Thư Giãn",
                Description = "Gói dịch vụ ưu đãi cuối tuần",
                Type = NursingPackageType.Special,
                State = StateType.Active,
                Price = 1200000,
                RegistrationLimit = 120,
                ImageUrl = "https://duonglaothienduc.com/wp-content/uploads/2023/02/thuvien3-1900x900resize_and_crop.jpg",
                NumberOfNurses = 2,
                Capacity = 12
            },
            new NursingPackage
            {
                Name = "Gói Thể Thao Năng Động",
                Description = "Gói dịch vụ thể dục thể thao",
                Type = NursingPackageType.Vip,
                State = StateType.Active,
                Price = 900000,
                RegistrationLimit = 90,
                ImageUrl = "https://random.com.vn/blog/wp-content/uploads/2020/09/tap-duong-sinh-5-1.jpg",
                NumberOfNurses = 1,
                Capacity = 9
            }
        };

}
