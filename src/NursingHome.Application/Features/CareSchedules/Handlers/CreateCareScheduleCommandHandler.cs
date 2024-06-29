using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.CareSchedules.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.CareSchedules.Handlers;
internal sealed class CreateCareScheduleCommandHandler(
     IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateCareScheduleCommand, MessageResponse>
{
    private readonly IGenericRepository<CareSchedule> _careScheduleRepository = unitOfWork.Repository<CareSchedule>();
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Shift> _shiftRepository = unitOfWork.Repository<Shift>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    public async Task<MessageResponse> Handle(CreateCareScheduleCommand request, CancellationToken cancellationToken)
    {
        if (!await _roomRepository.ExistsByAsync(_ => _.Id == request.RoomId, cancellationToken))
        {
            throw new NotFoundException(nameof(Room), request.RoomId);
        }
        foreach (var nurseSchedule in request.NurseSchedules)
        {
            if (!await _userRepository.ExistsByAsync(_ => _.Id == nurseSchedule.UserId, cancellationToken))
            {
                throw new NotFoundException(nameof(User), nurseSchedule.UserId);
            }
            if (!await _shiftRepository.ExistsByAsync(_ => _.Id == nurseSchedule.ShiftId, cancellationToken))
            {
                //throw new NotFoundException(nameof(Shift), nurseSchedule.ShiftId);
                throw new FieldResponseException(607, $"Could Not Find Shift With Id {nurseSchedule.ShiftId}");
            }
        }
        // chưa check điều kiện logic gì hết  
        var careSchedule = new CareSchedule();
        request.Adapt(careSchedule);

        await _careScheduleRepository.CreateAsync(careSchedule);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
