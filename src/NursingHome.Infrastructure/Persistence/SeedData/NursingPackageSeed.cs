using Bogus;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class NursingPackageSeed
{
    public static List<NursingPackage> DefaultNursingPackage =>
        new Faker<NursingPackage>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Type, f => f.PickRandom<NursingPackageType>())
            .RuleFor(p => p.Price, f => f.Finance.Amount())
            .RuleFor(p => p.RegistrationLimit, f => f.Random.Int(100, 1000))
            .RuleFor(p => p.Capacity, f => f.Random.Int(1, 10))
            .Generate(9);
}
