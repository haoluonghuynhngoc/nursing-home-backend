using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Appointments.Commands;
using NursingHome.Application.Features.Appointments.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Appointments.Handlers;
internal class RegisterAppointmentCommandHandler(
    ICurrentUserService currentUserService,
    IUnitOfWork unitOfWork) : IRequestHandler<RegisterAppointmentCommand, RegisterAppointmentResponse>
{
    private readonly IGenericRepository<Appointment> _appointmentRepository = unitOfWork.Repository<Appointment>();
    public async Task<RegisterAppointmentResponse> Handle(RegisterAppointmentCommand request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.FindCurrentUserAsync();
        if (user == null)
        {
            throw new NotFoundException("User Not logged in, please log in");
        }
        var appointment = new Appointment
        {
            Name = "Make an appointment to order a nursing package",
            NursingPackageId = request.NursingPackageId,
            Date = request.Date,
            Type = AppointmentType.None,
            UserId = user.Id,
            User = user,
        };
        await _appointmentRepository.CreateAsync(appointment, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new RegisterAppointmentResponse
        {
            Name = user.FullName,
            PhoneNumber = user.PhoneNumber,
            Date = DateOnly.FromDateTime(request.Date),
            Time = TimeOnly.FromDateTime(request.Date),
        };
    }
}
