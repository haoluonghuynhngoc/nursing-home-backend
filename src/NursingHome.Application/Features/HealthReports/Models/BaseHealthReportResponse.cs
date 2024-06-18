using NursingHome.Application.Models;

namespace NursingHome.Application.Features.HealthReports.Models;
public record BaseHealthReportResponse : BaseAuditableEntityResponse<int>
{
    public DateOnly Date { get; set; }
    public string? Notes { get; set; }
}
