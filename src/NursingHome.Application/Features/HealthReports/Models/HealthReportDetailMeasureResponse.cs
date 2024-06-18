using NursingHome.Application.Features.HealthCategories.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.HealthReports.Models;
public record HealthReportDetailMeasureResponse
{
    public int Id { get; set; }
    public float Value { get; set; }
    public HealthReportDetailMeasureStatus Status { get; set; }
    public string? Note { get; set; }
    public virtual MeasureUnitResponse MeasureUnit { get; set; } = default!;
}
