using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class HealthReportDetailMeasure : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public float Value { get; set; }
    public int MeasureUnitId { get; set; }
    public virtual MeasureUnit MeasureUnit { get; set; } = default!;
    public int HealthReportDetailId { get; set; }
    public virtual HealthReportDetail HealthReportDetail { get; set; } = default!;
}
