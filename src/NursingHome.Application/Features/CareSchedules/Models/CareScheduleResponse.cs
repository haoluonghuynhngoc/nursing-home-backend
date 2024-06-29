using NursingHome.Application.Features.NurseSchedule.Models;
using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.CareSchedules.Models;
public record CareScheduleResponse : BaseCareScheduleResponse
{
    public BaseRoomResponse Room { get; set; } = default!;
    public ICollection<CreateNurseScheduleRequest> NurseSchedules { get; set; } = new HashSet<CreateNurseScheduleRequest>();
}
