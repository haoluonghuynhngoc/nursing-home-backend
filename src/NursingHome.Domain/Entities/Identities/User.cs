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
    public GenderStatus Gender { get; set; }
    public string? DateOfBirth { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string? DeletedBy { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    [Projectable]
    public bool IsDeleted => DeletedAt != null;
    // ScheduledService
    public virtual ICollection<Elder> Elders { get; set; } = new HashSet<Elder>();
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<ScheduledService> ScheduledServices { get; set; } = new HashSet<ScheduledService>();
    public virtual ICollection<PotentialCustomer> PotentialCustomers { get; set; } = new HashSet<PotentialCustomer>();
    public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
    public virtual ICollection<Device> Devices { get; set; } = new HashSet<Device>();
    public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public virtual ICollection<NurseSchedule> NurseSchedules { get; set; } = new HashSet<NurseSchedule>();
    public virtual ICollection<FeedBack> FeedBacks { get; set; } = new HashSet<FeedBack>();
    public virtual ICollection<OrderDate> OrderDates { get; set; } = new HashSet<OrderDate>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    [Projectable]
    [NotMapped]
    public IEnumerable<Role> Roles => UserRoles.Select(ur => ur.Role);
}
