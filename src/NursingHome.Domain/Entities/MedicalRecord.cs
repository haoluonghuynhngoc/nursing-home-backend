using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class MedicalRecord : BaseEntity<Guid>
{
    public string? BloodType { get; set; }
    public string? Weight { get; set; }
    public string? Height { get; set; }
    public string? UnderlyingDisease { get; set; }
    public string? Note { get; set; }
    public Guid ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
}
