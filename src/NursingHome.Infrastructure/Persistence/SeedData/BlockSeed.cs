using Bogus;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class BlockSeed
{
    private static List<Block> Blocks => new List<Block>
    {
        new Block { Id = Guid.NewGuid(), Name = "Block A", TotalRoom = 50 },
        new Block { Id = Guid.NewGuid(), Name = "Block B", TotalRoom = 60 },
        new Block { Id = Guid.NewGuid(), Name = "Block C", TotalRoom = 70 }
    };

    public static List<Room> Rooms =>
        new Faker<Room>()
            .RuleFor(r => r.Name, f => f.Lorem.Word())
            .RuleFor(r => r.AvailableBed, f => f.Random.Bool())
            .RuleFor(r => r.TotalBed, f => f.Random.Int(1, 10))
            .RuleFor(r => r.UserBed, (f, r) => f.Random.Int(0, r.TotalBed))
            .FinishWith((f, r) => r.UnusedBed = r.TotalBed - r.UserBed)
            .RuleFor(r => r.Type, f => f.PickRandom<RoomType>())
            .RuleFor(r => r.Block, f => f.PickRandom(Blocks))
            .RuleFor(r => r.BlockId, (f, r) => r.Block.Id)
            .Generate(5);
}
