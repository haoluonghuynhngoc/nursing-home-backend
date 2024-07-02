using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.MeasureUnits.Models;
public record MeasureUnitResponse
{
    public int Id { get; init; }
    public string Name { get; set; } = default!;
    public StateType State { get; set; }
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
    public string UnitType { get; set; } = default!;
    public string? Description { get; set; }
    public int HealthCategoryId { get; set; }

}
