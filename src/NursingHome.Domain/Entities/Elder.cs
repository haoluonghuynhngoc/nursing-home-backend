using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Elder : BaseAuditableEntity<int>
{
    public string Name { get; set; } = default!;
    public string CCCD { get; set; } = default!;
    public string? DateOfBirth { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public DateOnly InDate { get; set; }
    public DateOnly OutDate { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }
    public int RoomId { get; set; }
    public virtual Room Room { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual MedicalRecord MedicalRecord { get; set; } = default!;
    public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public virtual ICollection<HealthReport> HealthReports { get; set; } = new HashSet<HealthReport>();
    //public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    public virtual ICollection<ScheduledServiceDetail> ScheduledServiceDetails { get; set; } = new HashSet<ScheduledServiceDetail>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
}
