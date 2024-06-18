using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthReports.Models;
public record CreateHealthReportDetailRequest
{
    public int HealthCategoryId { get; set; }
    public ICollection<CreateHealthReportDetailMeasureRequest> HealthReportDetailMeasures { get; set; } = new HashSet<CreateHealthReportDetailMeasureRequest>();
}
