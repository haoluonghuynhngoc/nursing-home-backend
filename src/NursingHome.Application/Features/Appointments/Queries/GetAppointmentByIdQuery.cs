using MediatR;
using NursingHome.Application.Features.Appointments.Models;

namespace NursingHome.Application.Features.Appointments.Queries;
public record GetAppointmentByIdQuery(int Id) : IRequest<AppointmentResponse>;
