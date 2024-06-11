using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class MeasureUnit : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public int HealthCategoryId { get; set; }
    public virtual HealthCategory HealthCategory { get; set; } = default!;
    public virtual ICollection<HealthReportDetailMeasure> HealthReportDetailMeasures { get; set; } = new HashSet<HealthReportDetailMeasure>();
}
