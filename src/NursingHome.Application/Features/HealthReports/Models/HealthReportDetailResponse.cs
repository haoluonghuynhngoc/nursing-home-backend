using NursingHome.Application.Features.HealthCategories.Models;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.HealthReports.Models;
public record HealthReportDetailResponse : BaseEntityResponse<int>
{
    public int HealthCategoryId { get; set; }
    public int HealthReportId { get; set; }
    public bool IsCritical { get; set; }
    public bool IsWarning { get; set; }
    public virtual BaseHealthCategoryResponse HealthCategory { get; set; } = default!;

    public ICollection<HealthReportDetailMeasureResponse> HealthReportDetailMeasures { get; set; } = new HashSet<HealthReportDetailMeasureResponse>();
}
