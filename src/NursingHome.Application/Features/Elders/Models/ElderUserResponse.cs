using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.Elders.Models;
public record ElderUserResponse : BaseElderResponse
{
    public BaseUserResponse User { get; set; } = default!;
}
