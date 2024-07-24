using NursingHome.Application.Features.EmployeeSchedules.Models;
using NursingHome.Application.Features.Rooms.Models;

namespace NursingHome.Application.Features.CareSchedules.Models;
public record CareScheduleResponse : BaseCareScheduleResponse
{
    public ICollection<RoomResponse> Rooms { get; set; } = new HashSet<RoomResponse>();
    //public RoomResponse Room { get; set; } = default!;
    public ICollection<EmployeeScheduleNoCareSchedulesResponse> EmployeeSchedules { get; set; } = new HashSet<EmployeeScheduleNoCareSchedulesResponse>();
}
