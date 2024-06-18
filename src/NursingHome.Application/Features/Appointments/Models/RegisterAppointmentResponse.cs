namespace NursingHome.Application.Features.Appointments.Models;
public record RegisterAppointmentResponse
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}
