using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Appointments.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Appointments.Handlers;
internal class UpdateAppointmentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateAppointmentCommand, MessageResponse>
{
    private readonly IGenericRepository<Appointment> _appointmentRepository = unitOfWork.Repository<Appointment>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();

    public async Task<MessageResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        if (request.NursingPackageId != null)
        {
            if (!await _nursingPackageRepository.ExistsByAsync(_ => _.Id == request.NursingPackageId, cancellationToken))
            {
                throw new NotFoundException(nameof(NursingPackage), request.UserId);
            }
        }
        foreach (var elder in request.Elders)
        {
            if (!await _elderRepository.ExistsByAsync(_ => _.Id == elder.Id, cancellationToken))
            {
                throw new NotFoundException(nameof(Elder), elder.Id);
            }
        }

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
