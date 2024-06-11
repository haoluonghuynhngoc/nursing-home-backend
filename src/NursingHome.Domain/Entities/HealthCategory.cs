using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class HealthCategory : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public string? ImageUrl { get; set; } = default!;
    public string? Description { get; set; }
    public virtual ICollection<HealthReportDetail> HealthReportDetails { get; set; } = new HashSet<HealthReportDetail>();
    public virtual ICollection<MeasureUnit> MeasureUnits { get; set; } = new HashSet<MeasureUnit>();
}
