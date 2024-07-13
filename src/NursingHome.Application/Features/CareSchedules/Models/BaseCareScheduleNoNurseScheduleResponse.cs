using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.CareSchedules.Models;
public record BaseCareScheduleNoNurseScheduleResponse : BaseCareScheduleResponse
{
    public RoomResponse Room { get; set; } = default!;
}
