using NursingHome.Application.Features.Elders.Models;

namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomResponse : BaseRoomResponse
{
    public ICollection<BaseElderResponse> Elders { get; set; } = new HashSet<BaseElderResponse>();
}
