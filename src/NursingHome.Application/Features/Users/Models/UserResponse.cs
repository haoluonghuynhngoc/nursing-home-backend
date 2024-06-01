using NursingHome.Application.Features.Devices.Models;
using NursingHome.Application.Features.Roles.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Users.Models;

public record UserResponse : BaseAuditableEntityResponse<Guid>
{
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Address { get; set; }
    public string? CCCD { get; set; }
    public bool IsActive { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public GenderStatus Gender { get; set; }
    public string? DateOfBirth { get; set; }

    public ICollection<DeviceResponse> Devices { get; set; } = new HashSet<DeviceResponse>();
    public ICollection<RoleResponse> Roles { get; set; } = new HashSet<RoleResponse>();
}
