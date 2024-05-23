namespace NursingHome.Domain.Entities;
public class AppointmentType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
}
