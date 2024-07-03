using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;

namespace NursingHome.Domain.Entities;
public class HealthReportDetail : BaseEntity<int>
{
    public int HealthCategoryId { get; set; }
    public virtual HealthCategory HealthCategory { get; set; } = default!;
    public int HealthReportId { get; set; }
    public virtual HealthReport HealthReport { get; set; } = default!;
    [Projectable]
    public bool IsWarning => HealthReportDetailMeasures != null && HealthReportDetailMeasures.Any(_ => _.Status == HealthReportDetailMeasureStatus.Warning);
    public virtual ICollection<HealthReportDetailMeasure> HealthReportDetailMeasures { get; set; } = new HashSet<HealthReportDetailMeasure>();
}
