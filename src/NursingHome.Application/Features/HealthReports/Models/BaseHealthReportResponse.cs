using NursingHome.Application.Features.Users.Models;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.HealthReports.Models;
public record BaseHealthReportResponse : BaseAuditableEntityResponse<int>
{
    public DateOnly Date { get; set; }
    public string? Notes { get; set; }
    public bool IsWarning { get; set; }
    public int ElderId { get; set; }
    public BaseUserResponse CreatorInfo { get; set; } = default!;

}
