using Bogus;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class ElderSeed
{
    public static List<Elder> Default =>
            new Faker<Elder>()
                .RuleFor(e => e.FullName, f => f.Name.FullName())
                .RuleFor(e => e.IdentityNumber, f => f.Random.Replace("######"))
                .RuleFor(e => e.DateOfBirth, f => f.Date.Past(80, DateTime.Now.AddYears(-60)).ToString("yyyy-MM-dd"))
                .RuleFor(e => e.Gender, f => f.PickRandom<GenderStatus>())
                .RuleFor(e => e.ImageUrl, f => f.Internet.Avatar())
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.Nationality, f => f.Address.Country())
                .RuleFor(e => e.Status, f => f.PickRandom<ElderStatus>())
                .RuleFor(e => e.Notes, f => f.Lorem.Sentence())
                .RuleFor(e => e.PriceRegister, f => f.Finance.Amount())
                .RuleFor(e => e.EffectiveDate, f => f.Date.Past(1))
                .RuleFor(e => e.ExpiryDate, (f, e) => e.EffectiveDate.AddYears(1))
                .RuleFor(e => e.InDate, f => f.Date.Past(1))
                .RuleFor(e => e.OutDate, (f, e) => e.InDate.AddDays(f.Random.Int(1, 30)))
                .Generate(5);

    public static List<Package> DefaultPackage =>
    new Faker<Package>()
        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
        .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
        .RuleFor(p => p.ImagePackage, f => f.Image.PicsumUrl())
        .RuleFor(p => p.NumberBed, f => f.Random.Int(1, 5))
        .RuleFor(p => p.Price, f => f.Finance.Amount())
        .RuleFor(p => p.Color, f => f.Commerce.Color())
        .RuleFor(p => p.Currency, f => "VND")
        .Generate(3);
}
