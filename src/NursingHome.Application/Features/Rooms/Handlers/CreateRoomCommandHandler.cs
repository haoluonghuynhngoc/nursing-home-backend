using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class CreateRoomCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateRoomCommand, MessageResponse>
{

    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    public async Task<MessageResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {

        if (!await _nursingPackageRepository.ExistsByAsync(_ => request.NursingPackageId == null || _.Id == request.NursingPackageId, cancellationToken))
        {
            throw new NotFoundException(nameof(NursingPackage), request.NursingPackageId);
        }

        if (!await _blockRepository.ExistsByAsync(_ => _.Id == request.BlockId))
        {
            throw new NotFoundException(nameof(Block), request.BlockId);
        }

        if (await _roomRepository.ExistsByAsync(_ => _.Name == request.Name && _.BlockId == request.BlockId))
        {
            throw new ConflictException($"Room Have Name {request.Name} In Block Have Block ID Is {request.BlockId}");
        }

        var room = request.Adapt<Room>();
        // room.TotalBed = 0;
        room.Type = RoomType.VacantRoom;

        await _roomRepository.CreateAsync(room);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
