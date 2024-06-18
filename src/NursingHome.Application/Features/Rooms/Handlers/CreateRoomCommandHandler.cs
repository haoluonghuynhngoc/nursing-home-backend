using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class CreateRoomCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateRoomCommand, MessageResponse>
{

    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    public async Task<MessageResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        if (request.NursingPackageId != null)
        {
            //var nursingPackageCheck = await _nursingPackageRepository.FindByAsync(x => x.Id == request.NursingPackageId)
            //    ?? throw new NotFoundException(nameof(NursingPackage), request.NursingPackageId.Value);
            if (!await _nursingPackageRepository.ExistsByAsync(_ => _.Id == request.NursingPackageId, cancellationToken))
            {
                throw new NotFoundException(nameof(NursingPackage), request.NursingPackageId);
            }
        }

        var roomCheckName = await _roomRepository.FindByAsync(x => x.Name == request.Name && x.BlockId == request.BlockId);
        if (roomCheckName != null)
        {
            throw new ConflictException($"Room Have Name {request.Name} In Block Have Block ID Is {request.BlockId}");
        }

        var block = await _blockRepository.FindByAsync(expression: _ => _.Id == request.BlockId)
           ?? throw new NotFoundException(nameof(Block), request.BlockId);

        var room = new Room
        {
            Name = request.Name,
            BlockId = request.BlockId,
            TotalBed = 0,
            NursingPackageId = request.NursingPackageId,
            Type = RoomType.VacantRoom,
        };

        await _roomRepository.CreateAsync(room);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
