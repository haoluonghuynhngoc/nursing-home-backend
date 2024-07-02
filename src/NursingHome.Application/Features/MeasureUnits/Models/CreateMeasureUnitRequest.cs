using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.MeasureUnits.Models;
public record CreateMeasureUnitRequest
{
    public string Name { get; set; } = default!;
    public string UnitType { get; set; } = default!;
    [JsonIgnore]
    public StateType State = StateType.Active;
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
    public string? Description { get; set; }
}
