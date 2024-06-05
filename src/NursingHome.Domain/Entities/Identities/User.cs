using EntityFrameworkCore.Projectables;
using Microsoft.AspNetCore.Identity;
using NursingHome.Domain.Common.Interfaces;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities.Identities;
public class User : IdentityUser<Guid>, IAuditableEntity
{
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Address { get; set; }
    public string? CCCD { get; set; }
    public bool IsActive { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public GenderStatus Gender { get; set; } = GenderStatus.Male;
    public string? DateOfBirth { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string? DeletedBy { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    [Projectable]
    public bool IsDeleted => DeletedAt != null;
    public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
    public virtual ICollection<Device> Devices { get; set; } = new HashSet<Device>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    [Projectable]
    [NotMapped]
    public IEnumerable<Role> Roles => UserRoles.Select(ur => ur.Role);

}
