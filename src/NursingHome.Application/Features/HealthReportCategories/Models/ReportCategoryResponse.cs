namespace NursingHome.Application.Features.HealthReportCategories.Models;
public sealed record ReportCategoryResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
