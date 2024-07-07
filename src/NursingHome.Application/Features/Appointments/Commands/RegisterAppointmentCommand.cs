using MediatR;
using NursingHome.Application.Features.Appointments.Models;

namespace NursingHome.Application.Features.Appointments.Commands;
public record RegisterAppointmentCommand : IRequest<RegisterAppointmentResponse>
{
    public int NursingPackageId { get; set; }
    public DateOnly Date { get; set; }
}
