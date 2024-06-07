namespace NursingHome.Domain.Entities;
public class HealthReportDetailMeasure
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public float Value { get; set; }
    public int MeasureUnitId { get; set; }
    public virtual MeasureUnit MeasureUnit { get; set; } = default!;
    public long HealthReportDetailId { get; set; }
    public virtual HealthReportDetail HealthReportDetail { get; set; } = default!;
}
