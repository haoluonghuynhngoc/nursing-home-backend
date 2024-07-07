using NursingHome.Application.Features.Shifts.Models;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.NurseSchedules.Models;
public record BaseCareSchedulesNurseSchedulesResponse
{
    public ShiftResponse Shift { get; set; } = default!;
    public BaseUserResponse User { get; set; } = default!;
}
