namespace NursingHome.Domain.Entities;
public class HealthReportCategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<HealthReportDetail> HealthReportDetails { get; set; } = new HashSet<HealthReportDetail>();
}
