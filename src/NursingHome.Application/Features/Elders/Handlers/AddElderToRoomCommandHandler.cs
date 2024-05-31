using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Elders.Handlers;
internal sealed class AddElderToRoomCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<AddElderToRoomCommand, MessageResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    public async Task<MessageResponse> Handle(AddElderToRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.FindByAsync(
            expression: _ => _.Id == request.RoomId)
             ?? throw new NotFoundException(nameof(Room), request.RoomId);

        var elder = await _elderRepository.FindByAsync(
            expression: _ => _.Id == request.ElderId)
             ?? throw new NotFoundException(nameof(Elder), request.RoomId);

        if (room.AvailableBed)
        {
            room.UserBed++;
            room.UnusedBed--;
            room.AvailableBed = room.UserBed < room.TotalBed;
        }
        else
        {
            throw new BadRequestException("Room is full");
        }
        await _roomRepository.UpdateAsync(room);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.AddElderSuccess);
    }
}

