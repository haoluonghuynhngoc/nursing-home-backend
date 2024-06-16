using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Rooms.Models;
public record BaseRoomResponse : BaseAuditableEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public int TotalBed { get; set; }
    public bool IsUsed { get; set; }
    public bool AvailableBed { get; set; }
    public int UnusedBed { get; set; }
    public int UserBed { get; set; }
    public RoomType? Type { get; set; }
    public int TotalElder { get; set; }
    public int BlockId { get; set; }
}
