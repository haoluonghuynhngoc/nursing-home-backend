using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Appointments.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Appointments.Handlers;
internal class CreateAppointmentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateAppointmentCommand, MessageResponse>
{
    private readonly IGenericRepository<Appointment> _appointmentRepository = unitOfWork.Repository<Appointment>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    private readonly IGenericRepository<Contract> _contractRepository = unitOfWork.Repository<Contract>();
    public async Task<MessageResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        if (request.NursingPackageId != null)
        {
            if (!await _nursingPackageRepository.ExistsByAsync(_ => _.Id == request.NursingPackageId, cancellationToken))
            {
                throw new NotFoundException(nameof(NursingPackage), request.NursingPackageId);
            }
        }
        if (request.ContractId != null)
        {
            if (!await _contractRepository.ExistsByAsync(_ => _.Id == request.ContractId, cancellationToken))
            {
                throw new NotFoundException(nameof(Contract), request.ContractId);
            }
        }
        foreach (var elder in request.Elders)
        {
            if (!await _elderRepository.ExistsByAsync(_ => _.Id == elder.Id, cancellationToken))
            {
                throw new NotFoundException(nameof(Elder), elder.Id);
            }
        }

        var appointmentElder = await _elderRepository.FindAsync(_ =>
        request.Elders.Select(_ => _.Id).Contains(_.Id), isAsNoTracking: false);

        var appointment = request.Adapt<Appointment>();
        appointment.Elders = appointmentElder;
        await _appointmentRepository.CreateAsync(appointment, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
