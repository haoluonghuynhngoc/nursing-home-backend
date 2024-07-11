using NursingHome.Application.Features.CareSchedules.Models;
using NursingHome.Application.Features.Shifts.Models;

namespace NursingHome.Application.Features.NurseSchedules.Models;
public record BaseNurseScheduleNoNurseResponse
{
    public BaseCareScheduleNoNurseScheduleResponse CareSchedule { get; set; } = default!;
    public ShiftResponse Shift { get; set; } = default!;
}
