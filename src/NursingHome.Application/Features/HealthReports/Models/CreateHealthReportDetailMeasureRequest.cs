using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.HealthReports.Models;
public record CreateHealthReportDetailMeasureRequest
{
    public float Value { get; set; }
    public HealthReportDetailMeasureStatus Status { get; set; }
    public string? Note { get; set; }
    public int MeasureUnitId { get; set; }
}
