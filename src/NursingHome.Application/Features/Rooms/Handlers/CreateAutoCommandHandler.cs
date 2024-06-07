using Bogus;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class CreateAutoCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateAutoCommand, MessageResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    public async Task<MessageResponse> Handle(CreateAutoCommand request, CancellationToken cancellationToken)
    {
        var block = await _blockRepository.FindByAsync(
             expression: _ => _.Id == request.BlockId)
             ?? throw new NotFoundException(nameof(Block), request.BlockId);

        List<Room> DefaultRoom = new Faker<Room>()
         .RuleFor(a => a.Name, r => $"Room Temporary {r.Random.Number(0, 100)}")
         .RuleFor(a => a.TotalBed, r => 0)
         .RuleFor(r => r.UnusedBed, r => 0)
         .RuleFor(r => r.UserBed, r => 0)
         .RuleFor(r => r.AvailableBed, r => false)
         .RuleFor(a => a.Type, f => RoomType.VacantRoom)
         .RuleFor(a => a.Block, f => block)
         .Generate(request.TotalRoom);

        foreach (var room in DefaultRoom)
        {
            await _roomRepository.CreateAsync(room);
        }
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
