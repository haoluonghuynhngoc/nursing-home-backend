using NursingHome.Application.Features.HealthCategories.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.HealthReports.Models;
public record HealthReportDetailMeasureResponse : BaseEntityResponse<int>
{
    public float Value { get; set; }
    public HealthReportDetailMeasureStatus Status { get; set; }
    public string? Note { get; set; }
    public int MeasureUnitId { get; set; }
    public int HealthReportDetailId { get; set; }
    public MeasureUnitResponse MeasureUnit { get; set; } = default!;
}
