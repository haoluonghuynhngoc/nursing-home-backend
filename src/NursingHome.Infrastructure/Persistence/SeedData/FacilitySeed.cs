using Bogus;
using NursingHome.Domain.Entities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class FacilitySeed
{
    public static Facility Default
    {
        get
        {
            var areas = new Faker<Area>()
                .RuleFor(a => a.Name, f => f.PickRandom("Block A", "Block B", "Block C"))
                .RuleFor(a => a.Description, f => f.Lorem.Paragraph(1))
                .RuleFor(a => a.Status, f => f.PickRandom("In use", "Under maintenance", "Vacant"))
                .RuleFor(a => a.Type, f => f.PickRandom("Nursing Home", "Retirement Community", "Assisted Living Facility", "Rehabilitation Center"))
                .RuleFor(a => a.TotalFloor, f => f.Random.Number(1, 30));
            return new Facility
            {
                Name = "Nursing Home",
                ImageFacility = "",
                Type = "Independent Living",
                Address = "1234 Nursing Home",
                Phone = "1234567890",
                Description = "None",
                Status = "Nursing Care",
                Website = "NursingHome@gmail.com",
                Areas = new HashSet<Area>(areas.Generate(3)) // map list to hashset
            };
        }
    }
}
