using NursingHome.Application.Features.HealthCategories.Models;

namespace NursingHome.Application.Features.HealthReports.Models;
public record HealthReportDetailResponse
{
    public virtual BaseHealthCategoryResponse HealthCategory { get; set; } = default!;
    public ICollection<HealthReportDetailMeasureResponse> HealthReportDetailMeasures { get; set; } = new HashSet<HealthReportDetailMeasureResponse>();
}
