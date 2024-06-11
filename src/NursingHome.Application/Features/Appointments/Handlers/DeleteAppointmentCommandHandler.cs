using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Appointments.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Appointments.Handlers;
internal class DeleteAppointmentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteAppointmentCommand, MessageResponse>
{
    private readonly IGenericRepository<Appointment> _appointmentRepository = unitOfWork.Repository<Appointment>();
    public async Task<MessageResponse> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (appointment is null)
        {
            throw new NotFoundException(nameof(Appointment), request.Id);
        }

        await _appointmentRepository.DeleteAsync(appointment);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeletedSuccess);
    }
}
