using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    //public bool AvailableBed { get; set; }
    public int TotalBed { get; set; }
    //public int UnusedBed { get; set; }
    //public int UserBed { get; set; }
    public RoomType? Type { get; set; }
    public int BlockId { get; set; }
    public RoomBlock Block { get; set; } = default!;
    public ICollection<RoomElder> Elders { get; set; } = new HashSet<RoomElder>();

}
