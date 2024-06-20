using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class MedicalRecord : BaseAuditableEntity<int>
{
    public string? BloodType { get; set; }
    public string? Weight { get; set; }
    public string? Move { get; set; }
    public string? Height { get; set; }
    public string? UnderlyingDisease { get; set; }
    public string? Note { get; set; }
    public int ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public virtual ICollection<DiseaseCategory> DiseaseCategories { get; set; } = new HashSet<DiseaseCategory>();
}
