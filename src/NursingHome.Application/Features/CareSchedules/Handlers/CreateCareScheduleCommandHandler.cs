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
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<EmployeeType> _employeeTypeRepository = unitOfWork.Repository<EmployeeType>();
    private readonly IGenericRepository<EmployeeSchedule> _employeeScheduleRepository = unitOfWork.Repository<EmployeeSchedule>();

    public async Task<MessageResponse> Handle(CreateCareScheduleCommand request, CancellationToken cancellationToken)
    {
        //if (!await _roomRepository.ExistsByAsync(_ => _.Id == request.RoomId, cancellationToken))
        //{
        //    throw new NotFoundException(nameof(Room), request.RoomId);
        //}

        var rooms = await _roomRepository.FindAsync(_ =>
        request.Rooms.Select(_ => _.Id).Contains(_.Id), isAsNoTracking: false);

        // chưa test 
        foreach (var room in rooms)
        {
            if (room.Elders == null || room.Elders.Count() <= 0)
            {
                throw new FieldResponseException(617, "Unoccupied rooms are not scheduled");
            }
        }

        foreach (var iteam in request.EmployeeSchedules)
        {
            if (!await _employeeTypeRepository.ExistsByAsync(_ => _.Id == iteam.EmployeeTypeId, cancellationToken))
            {
                throw new NotFoundException(nameof(EmployeeType), iteam.EmployeeTypeId);
            }
            if (!await _userRepository.ExistsByAsync(_ => _.Id == iteam.UserId, cancellationToken))
            {
                throw new NotFoundException(nameof(User), iteam.UserId);
            }
        }
        var careSchedules = request.Adapt<CareSchedule>();
        careSchedules.Rooms = rooms;

        await _careScheduleRepository.CreateAsync(careSchedules, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
