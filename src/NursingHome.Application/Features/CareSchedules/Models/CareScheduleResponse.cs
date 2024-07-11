using NursingHome.Application.Features.NurseSchedules.Models;
using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.CareSchedules.Models;
public record CareScheduleResponse : BaseCareScheduleResponse
{
    public BaseRoomResponse Room { get; set; } = default!;
    public ICollection<BaseNurseScheduledNoCareScheduleResponse> NurseSchedules { get; set; } = new HashSet<BaseNurseScheduledNoCareScheduleResponse>();
}
