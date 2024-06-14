using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.NursingPackages.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.NursingPackages.Handlers;
internal class AddNursingPackageToRoomCommandHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<AddNursingPackageToRoomCommand, MessageResponse>
{
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    public async Task<MessageResponse> Handle(AddNursingPackageToRoomCommand request, CancellationToken cancellationToken)
    {

        var nursingPackage = await _nursingPackageRepository.FindByAsync(
            expression: _ => _.Id == request.NursingPackageId)
            ?? throw new NotFoundException(nameof(NursingPackage), request.NursingPackageId);

        if (request.Rooms != null && request.Rooms.Any())
        {
            foreach (var roomId in request.Rooms)
            {
                var room = await _roomRepository.FindByAsync(
                    expression: _ => _.Id == roomId)
                    ?? throw new NotFoundException(nameof(Room), request.NursingPackageId);
                if (room.Type == RoomType.UsableRoom)
                {
                    throw new BadRequestException($"Room Have Id Is {room.Id} Already Has Nursing Package");
                }
                room.Type = RoomType.UsableRoom;
                room.TotalBed = nursingPackage.Capacity; // Set Total Bed Of Room
                nursingPackage.Rooms?.Add(room);
            }
        }
        await _nursingPackageRepository.UpdateAsync(nursingPackage);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
