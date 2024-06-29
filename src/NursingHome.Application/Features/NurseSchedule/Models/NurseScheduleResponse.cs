using NursingHome.Application.Features.Shifts.Models;
using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.NurseSchedule.Models;
public record NurseScheduleResponse
{
    public ShiftResponse Shift { get; set; } = default!;
    public BaseUserResponse User { get; set; } = default!;
}
