using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.Blocks.Models;
public sealed record BlockResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    //public int UsedRooms { get; set; }
    //public int UnUsedRooms { get; set; }
    public int TotalRoom { get; set; }
    public ICollection<RoomResponse> Rooms { get; set; } = new HashSet<RoomResponse>();
}
