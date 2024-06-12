using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class CreateRoomCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateRoomCommand, MessageResponse>
{

    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    public async Task<MessageResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var roomCheckName = await _roomRepository.FindByAsync(x => x.Name == request.Name);

        if (roomCheckName != null)
        {
            throw new ConflictException($"Room Have Name {request.Name} In DataBase");
        }

        var block = await _blockRepository.FindByAsync(expression: _ => _.Id == request.BlockId)
           ?? throw new NotFoundException(nameof(Block), request.BlockId);

        var room = new Room
        {
            Name = request.Name,
            BlockId = request.BlockId,
            TotalBed = 0,
        };

        await _roomRepository.CreateAsync(room);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
