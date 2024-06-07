namespace NursingHome.Domain.Entities;
public class MeasureUnit
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int HealthCategoryId { get; set; }
    public virtual HealthCategory HealthCategory { get; set; } = default!;
    public virtual ICollection<HealthReportDetailMeasure> HealthReportDetailMeasures { get; set; } = new HashSet<HealthReportDetailMeasure>();
}
