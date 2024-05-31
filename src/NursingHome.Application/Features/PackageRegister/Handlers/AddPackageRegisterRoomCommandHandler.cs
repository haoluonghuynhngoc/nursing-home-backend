using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.PackageRegister.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageRegister.Handlers;
internal sealed class AddPackageRegisterRoomCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<AddPackageRegisterRoomCommand, MessageResponse>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    private readonly IGenericRepository<PackageType> _packageTypeRepository = unitOfWork.Repository<PackageType>();
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    public async Task<MessageResponse> Handle(AddPackageRegisterRoomCommand request, CancellationToken cancellationToken)
    {
        var package = await _packageRepository.FindByAsync(
            expression: _ => _.Id == request.PackageRegisterId)
            ?? throw new NotFoundException($"Package Have Id {request.PackageRegisterId} Is Not Found");

        if (request.Rooms != null && request.Rooms.Any())
        {
            foreach (var roomId in request.Rooms)
            {
                var room = await _roomRepository.FindByAsync(
                    expression: _ => _.Id == roomId)
                    ?? throw new NotFoundException($"Room Have Id {roomId} Is Not Found");
                room.TotalBed = package.NumberBed;
                room.UserBed = 0;
                room.UnusedBed = room.TotalBed - room.UserBed;
                room.AvailableBed = room.UserBed < room.TotalBed;
                package.Rooms?.Add(room);
            }
        }
        await _packageRepository.UpdateAsync(package);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
