using NursingHome.Application.Features.Elders.Models;

namespace NursingHome.Application.Features.HealthReports.Models;
public record HealthReportResponse : BaseHealthReportResponse
{
    public ICollection<HealthReportDetailResponse> HealthReportDetails { get; set; } = new HashSet<HealthReportDetailResponse>();
    public BaseElderResponse Elder { get; set; } = default!;
}
