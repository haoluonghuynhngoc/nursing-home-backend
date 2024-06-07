using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Elder : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string DateOfBirth { get; set; } = default!;
    [Column(TypeName = "nvarchar(24)")]
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public ElderStatus Status { get; set; }
    public string? Notes { get; set; }
    public Guid RoomId { get; set; }
    public virtual Room Room { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual MedicalRecord MedicalRecord { get; set; } = default!;
    public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public virtual ICollection<HealthReport> HealthReports { get; set; } = new HashSet<HealthReport>();
    public virtual ICollection<ElderServicePackage> ElderServicePackages { get; set; } = new HashSet<ElderServicePackage>();
    public virtual ICollection<ElderNursingPackage> ElderNursingPackages { get; set; } = new HashSet<ElderNursingPackage>();
}
