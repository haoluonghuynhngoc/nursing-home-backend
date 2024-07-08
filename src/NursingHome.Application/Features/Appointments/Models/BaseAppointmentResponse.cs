using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Appointments.Models;
public record BaseAppointmentResponse : BaseAuditableEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public string? Content { get; set; }
    public DateOnly Date { get; set; }
    public AppointmentStatus Status { get; set; }
    public AppointmentType Type { get; set; }
    public string? Notes { get; set; }
    //public Guid UserId { get; set; }
    //public int? NursingPackageId { get; set; }
}
