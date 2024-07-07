using MediatR;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Appointments.Commands;
public record CreateAppointmentCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public AppointmentType Type { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
    public ICollection<CreateElderAppointmentRequest> Elders { get; set; } = new HashSet<CreateElderAppointmentRequest>();
}
