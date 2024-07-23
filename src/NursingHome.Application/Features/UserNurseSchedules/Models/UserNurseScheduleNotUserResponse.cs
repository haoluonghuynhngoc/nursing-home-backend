using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.UserNurseSchedules.Models;
public record UserNurseScheduleNotUserResponse
{
    public BaseUserResponse User { get; set; } = default!;
}
