namespace NursingHome.Application.Features.HealthCategories.Models;
public record MeasureUnitResponse
{
    public int Id { get; init; }
    public string Name { get; set; } = default!;
    public string UnitType { get; set; } = default!;
    public string? Description { get; set; }
    public int HealthCategoryId { get; set; }
}
