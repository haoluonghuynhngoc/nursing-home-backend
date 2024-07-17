using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.MeasureUnits.Commands;
public sealed record CreateMeasureUnitCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int HealthCategoryId { get; set; }
    public string Name { get; set; } = default!;
    public string UnitType { get; set; } = default!;
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
    public string? Description { get; set; }
}

