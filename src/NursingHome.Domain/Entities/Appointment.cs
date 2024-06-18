using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Appointment : BaseAuditableEntity<int>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public AppointmentType Type { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public int? NursingPackageId { get; set; }
    public virtual NursingPackage NursingPackage { get; set; } = default!;
}
