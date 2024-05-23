using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Appointment : BaseEntity<Guid>
{
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }
    public DateTime VistedDay { get; set; }
    public string? Location { get; set; }
    public string? Status { get; set; }
    public string? Note { get; set; }
    public int AppointmentTypeId { get; set; }
    public virtual AppointmentType AppointmentType { get; set; } = default!;
    public virtual ICollection<AppointmentUser> AppointmentUsers { get; set; } = new List<AppointmentUser>();
    [Projectable]
    [NotMapped]
    public IEnumerable<User> Users => AppointmentUsers.Select(ap => ap.User);
}
