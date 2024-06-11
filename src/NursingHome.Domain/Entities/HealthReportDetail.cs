using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class HealthReportDetail : BaseEntity<int>
{
    public int HealthCategoryId { get; set; }
    public virtual HealthCategory HealthCategory { get; set; } = default!;
    public int HealthReportId { get; set; }
    public virtual HealthReport HealthReport { get; set; } = default!;
    public virtual ICollection<HealthReportDetailMeasure> HealthReportDetailMeasures { get; set; } = new HashSet<HealthReportDetailMeasure>();
}
