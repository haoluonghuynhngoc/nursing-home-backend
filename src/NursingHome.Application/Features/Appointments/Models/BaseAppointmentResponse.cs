using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Appointments.Models;
public record BaseAppointmentResponse : BaseAuditableEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public AppointmentType Type { get; set; }
    public string? Notes { get; set; }
    //    public Guid UserId { get; set; }
    //    public virtual User User { get; set; } = default!;
    //    public int? NursingPackageId { get; set; }
    //    public virtual NursingPackage NursingPackage { get; set; } = default!;
}
