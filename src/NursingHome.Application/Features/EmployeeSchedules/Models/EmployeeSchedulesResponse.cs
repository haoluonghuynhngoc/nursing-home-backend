using NursingHome.Application.Features.CareSchedules.Models;
using NursingHome.Application.Features.EmployeeTypes.Models;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.EmployeeSchedules.Models;
public record EmployeeSchedulesResponse
{
    public virtual BaseUserResponse User { get; set; } = default!;
    public virtual BaseEmployeeTypeResponse EmployeeType { get; set; } = default!;
    public virtual BaseCareSchedulesRoomResponse CareSchedule { get; set; } = default!;
}
