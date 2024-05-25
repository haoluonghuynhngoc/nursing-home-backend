using Bogus;
using NursingHome.Domain.Entities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class BlockSeed
{
    public static List<Block> Default =>
        new Faker<Block>()
       .RuleFor(a => a.Name, f => f.PickRandom("Block A", "Block B", "Block C"))
       .RuleFor(a => a.Description, f => f.Lorem.Paragraph(1))
       .RuleFor(a => a.Status, f => f.PickRandom("In use", "Under maintenance", "Vacant"))
       .RuleFor(a => a.Type, f => f.PickRandom("Nursing Home", "Retirement Community", "Assisted Living Facility", "Rehabilitation Center"))
       .RuleFor(a => a.TotalFloor, f => f.Random.Number(1, 30)).Generate(3);

}
