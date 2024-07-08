using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Appointments.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Appointments.Handlers;
internal class ChangeStatusAppointmentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeStatusAppointmentCommand, MessageResponse>
{
    private readonly IGenericRepository<Appointment> _appointmentRepository = unitOfWork.Repository<Appointment>();

    public async Task<MessageResponse> Handle(ChangeStatusAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.FindByAsync(
            expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Appointment Have Id {request.Id} Is Not Found");
        request.Adapt(appointment);

        await _appointmentRepository.UpdateAsync(appointment);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
