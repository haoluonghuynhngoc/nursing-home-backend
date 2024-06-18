using MediatR;
using NursingHome.Application.Features.HealthReports.Models;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.HealthReports.Commands;
public sealed record CreateHealthReportCommand : IRequest<MessageResponse>
{
    public int ElderId { get; set; }
    public string? Notes { get; set; }
    public ICollection<CreateHealthReportDetailRequest> HealthReportDetails { get; set; } = new HashSet<CreateHealthReportDetailRequest>();
}
