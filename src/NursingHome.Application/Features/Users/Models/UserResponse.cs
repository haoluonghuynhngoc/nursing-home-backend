using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Roles.Models;

namespace NursingHome.Application.Features.Users.Models;
public record UserResponse : BaseUserResponse
{
    public ICollection<RoleResponse> Roles { get; set; } = new HashSet<RoleResponse>();
    public virtual ICollection<BaseElderResponse> Elders { get; set; } = new HashSet<BaseElderResponse>();
}
