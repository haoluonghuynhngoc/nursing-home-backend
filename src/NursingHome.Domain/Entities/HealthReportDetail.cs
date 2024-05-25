namespace NursingHome.Domain.Entities;
public class HealthReportDetail
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public float Result { get; set; }
    public string? Unit { get; set; }
    public string? Status { get; set; }
    public string? Note { get; set; }
    public Guid HealthReportId { get; set; }
    public HealthReport HealthReport { get; set; } = default!;
    public int HealthReportCategoryId { get; set; }
    public HealthReportCategory HealthReportCategory { get; set; } = default!;
}