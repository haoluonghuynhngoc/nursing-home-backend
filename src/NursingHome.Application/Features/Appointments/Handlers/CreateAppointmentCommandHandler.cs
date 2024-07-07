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

    public async Task<MessageResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
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
