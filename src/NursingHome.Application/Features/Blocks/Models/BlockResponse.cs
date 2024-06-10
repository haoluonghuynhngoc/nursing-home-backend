namespace NursingHome.Application.Features.Blocks.Models;
public sealed record BlockResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int UsedRooms { get; set; }
    public int UnUsedRooms { get; set; }
    public int TotalRoom { get; set; }
    public ICollection<BlockRoom> Rooms { get; set; } = new HashSet<BlockRoom>();
}
