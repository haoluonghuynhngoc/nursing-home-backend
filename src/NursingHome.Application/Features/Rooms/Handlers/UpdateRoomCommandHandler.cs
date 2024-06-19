using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class UpdateRoomCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateRoomCommand, MessageResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    public async Task<MessageResponse> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.FindByAsync(
            expression: _ => _.Id == request.Id)
             ?? throw new NotFoundException(nameof(Room), request.Id);

        if (await _roomRepository.ExistsByAsync(_ => _.Id != request.Id && (_.Name == request.Name && _.BlockId == room.BlockId)))
        {
            throw new ConflictException($"Room Have Name {request.Name} In Block Have Block ID Is {room.BlockId}");
        }

        request.Adapt(room);
        await _roomRepository.UpdateAsync(room);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
