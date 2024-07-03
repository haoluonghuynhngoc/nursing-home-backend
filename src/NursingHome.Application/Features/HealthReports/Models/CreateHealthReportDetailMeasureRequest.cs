using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.HealthReports.Models;
public record CreateHealthReportDetailMeasureRequest
{
    public float Value { get; set; }
    [JsonIgnore]
    public HealthReportDetailMeasureStatus Status { get; set; }
    public string? Note { get; set; }
    public int MeasureUnitId { get; set; }
}
