namespace NursingHome.Application.Features.HealthCategories.Models;
public sealed record HealthCategoryResponse
{
    public int Id { get; init; }
    public string Name { get; set; } = default!;
    public string? ImageUrl { get; set; } = default!;
    public string? Description { get; set; }
    //public  ICollection<HealthReportDetail> HealthReportDetails { get; set; } = new HashSet<HealthReportDetail>();
    //public  ICollection<MeasureUnit> MeasureUnits { get; set; } = new HashSet<MeasureUnit>();
}
