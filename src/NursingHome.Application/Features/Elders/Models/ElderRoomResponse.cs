using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.Elders.Models;
public record ElderRoomResponse : BaseElderResponse
{
    public BaseRoomResponse Room { get; set; } = default!;
}
