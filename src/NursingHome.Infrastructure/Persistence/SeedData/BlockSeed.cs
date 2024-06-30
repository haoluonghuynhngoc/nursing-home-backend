using Bogus;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class BlockSeed
{
    public static List<Block> Default
    {
        get
        {
            var blockNames = new List<string> { "Block A", "Block B", "Block C" };
            var faker = new Faker<Block>().StrictMode(true)
                .RuleFor(a => a.Id, f => f.IndexFaker + 1)
                .RuleFor(a => a.Name, (f, a) => blockNames[f.IndexFaker])
                .RuleFor(a => a.Rooms, f => new HashSet<Room>());
            var generatedBlocks = faker.Generate(3);

            foreach (var block in generatedBlocks)
            {
                var rooms = GenerateRoomsForBlock(12);
                foreach (var room in rooms)
                {
                    block.Rooms.Add(room);
                }
            }

            return generatedBlocks;
        }
    }

    private static IEnumerable<Room> GenerateRoomsForBlock(int roomCount)
    {
        return new Faker<Room>()
            .RuleFor(a => a.Name, r => $"Room VacantRoom")
            //.RuleFor(a => a.TotalBed, r => 0)
            .RuleFor(r => r.Type, f => RoomType.VacantRoom)
            .Generate(roomCount);
    }

}
