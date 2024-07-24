using NursingHome.Application.Features.CareSchedules.Models;
using NursingHome.Application.Features.EmployeeTypes.Models;

namespace NursingHome.Application.Features.EmployeeSchedules.Models;
public record EmployeeScheduleNoUserResponse
{
    public virtual BaseEmployeeTypeResponse EmployeeType { get; set; } = default!;
    public virtual BaseCareSchedulesRoomResponse CareSchedule { get; set; } = default!;
}

