using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Appointments.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Appointments.Handlers;
internal class UpdateAppointmentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateAppointmentCommand, MessageResponse>
{
    private readonly IGenericRepository<Appointment> _appointmentRepository = unitOfWork.Repository<Appointment>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.FindByAsync(x => x.Id == request.Id
        , includeFunc: _ => _.Include(x => x.Elders), cancellationToken: cancellationToken);

        if (appointment is null)
        {
            throw new NotFoundException(nameof(Appointment), request.Id);
        }

        request.Adapt(appointment);

        var appointmentElder = await _elderRepository.FindAsync(_ =>
         request.Elders.Select(_ => _.Id).Contains(_.Id), isAsNoTracking: false);
        appointment.Elders = appointmentElder;

        await _appointmentRepository.UpdateAsync(appointment);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
