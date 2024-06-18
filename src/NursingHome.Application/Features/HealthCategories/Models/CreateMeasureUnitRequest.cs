namespace NursingHome.Application.Features.HealthCategories.Models;
public record CreateMeasureUnitRequest
{
    public string Name { get; set; } = default!;
    public string UnitType { get; set; } = default!;
    public string? Description { get; set; }
}
