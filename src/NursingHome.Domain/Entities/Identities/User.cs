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
    public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
    public virtual ICollection<NurseElder> NurseElders { get; set; } = new HashSet<NurseElder>();
    public virtual ICollection<FeedBack> FeedBacks { get; set; } = new HashSet<FeedBack>();
    public virtual ICollection<AppointmentUser> AppointmentUsers { get; set; } = new HashSet<AppointmentUser>();
    [Projectable]
    [NotMapped]
    public IEnumerable<Appointment> Appointments => AppointmentUsers.Select(ap => ap.Appointment);
    public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public virtual ICollection<ElderUser> ElderUsers { get; set; } = new HashSet<ElderUser>();
    [Projectable]
    [NotMapped]
    public IEnumerable<Elder> Elders => ElderUsers.Select(eu => eu.Elder);
    public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    //public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
    public virtual ICollection<HealthReport> HealthReports { get; set; } = new HashSet<HealthReport>();
    public virtual ICollection<UserCareSchedule> UserCareSchedules { get; set; } = new HashSet<UserCareSchedule>();
    [Projectable]
    [NotMapped]
    public IEnumerable<CareSchedule> CareSchedules => UserCareSchedules.Select(uc => uc.CareSchedule);
    public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    [Projectable]
    [NotMapped]
    public IEnumerable<Role> Roles => UserRoles.Select(ur => ur.Role);

}
