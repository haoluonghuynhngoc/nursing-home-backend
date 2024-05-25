using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class AppointmentUser
{
    public Guid AppointmentId { get; set; }
    public virtual Appointment Appointment { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public bool IsAccepted { get; set; }
    public bool IsVisited { get; set; }
    public string? Note { get; set; }

}