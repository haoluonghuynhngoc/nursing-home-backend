using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Appointments.Models;
public record AppointmentResponse : BaseAuditableEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public AppointmentType Type { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
}
