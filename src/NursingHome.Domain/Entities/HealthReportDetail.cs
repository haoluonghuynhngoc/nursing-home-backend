namespace NursingHome.Domain.Entities;
public class HealthReportDetail
{
    public long Id { get; set; }
    public int HealthCategoryId { get; set; }
    public virtual HealthCategory HealthCategory { get; set; } = default!;
    public Guid HealthReportId { get; set; }
    public virtual HealthReport HealthReport { get; set; } = default!;
    public virtual ICollection<HealthReportDetailMeasure> HealthReportDetailMeasures { get; set; } = new HashSet<HealthReportDetailMeasure>();
}
