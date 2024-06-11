using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Appointments.Commands;
public record DeleteAppointmentCommand(int Id) : IRequest<MessageResponse>;