using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.CareSchedules.Models;
public record BaseNurseScheduleCareScheduleResponse : BaseCareScheduleResponse
{
    public BaseRoomResponse Room { get; set; } = default!;
}
