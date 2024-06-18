using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.HealthReports.Commands;
public sealed record UpdateHealthReportCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string? Notes { get; set; }
    //public ICollection<HealthReportDetail> HealthReportDetails { get; set; } = new HashSet<HealthReportDetail>();
    //public int ElderId { get; set; }
    //public Elder Elder { get; set; } = default!;
}
