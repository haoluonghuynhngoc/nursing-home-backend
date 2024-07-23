using NursingHome.Application.Features.NurseSchedules.Models;
using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.CareSchedules.Models;
public record CareScheduleResponse : BaseCareScheduleResponse
{
    public RoomResponse Room { get; set; } = default!;
    public ICollection<NurseScheduleResponse> NurseSchedules { get; set; } = new HashSet<NurseScheduleResponse>();
}
