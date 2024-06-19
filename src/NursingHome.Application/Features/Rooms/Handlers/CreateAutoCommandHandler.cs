using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class CreateAutoCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateAutoCommand, MessageResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    public async Task<MessageResponse> Handle(CreateAutoCommand request, CancellationToken cancellationToken)
    {
        if (!await _nursingPackageRepository.ExistsByAsync(_ => request.NursingPackageId == null || _.Id == request.NursingPackageId, cancellationToken))
        {
            throw new NotFoundException(nameof(NursingPackage), request.NursingPackageId);
        }

        if (!await _blockRepository.ExistsByAsync(_ => _.Id == request.BlockId))
        {
            throw new NotFoundException(nameof(Block), request.BlockId);
        }

        int lastIndex = (await _roomRepository
            .FindAsync(_ => _.BlockId == request.BlockId, cancellationToken: cancellationToken)).MaxBy(_ => _.Index)?.Index ?? 0;

        var rooms = Enumerable.Range(1, request.TotalRoom)
            .Select(rackIndex => new Room
            {
                Index = ++lastIndex,
                Name = $"{request.Name}{lastIndex}",
                TotalBed = 0,
                BlockId = request.BlockId,
                Type = RoomType.VacantRoom,
                NursingPackageId = request.NursingPackageId,
            })
            .ToList();

        await _roomRepository.CreateRangeAsync(rooms);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
