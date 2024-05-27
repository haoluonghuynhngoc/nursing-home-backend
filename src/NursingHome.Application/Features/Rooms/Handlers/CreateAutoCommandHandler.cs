using Bogus;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using System.Diagnostics.Metrics;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class CreateAutoCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateAutoCommand, MessageResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Block> _blockRepository = unitOfWork.Repository<Block>();
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    public async Task<MessageResponse> Handle(CreateAutoCommand request, CancellationToken cancellationToken)
    {
        var block = await _blockRepository.FindByAsync(
             expression: _ => _.Id == request.BlockId)
             ?? throw new NotFoundException(nameof(Block), request.BlockId);

        var package = await _packageRepository.FindByAsync(
             expression: _ => _.Id == request.PackageId);

        List<Room> DefaultRoom = new Faker<Room>()
         .RuleFor(a => a.Name, r => $"Room Temporary {r.Random.Number(0, 100)}")
         .RuleFor(a => a.Capacity, r => r.Random.Number(1, 30))
         .RuleFor(a => a.AvailableBed, r => r.Random.Bool())
         .RuleFor(a => a.TotalBed, r => r.Random.Number(0, 6))
         .RuleFor(r => r.UnusedBed, r => 6)
         .RuleFor(r => r.UserBed, (f, r) => 6 - r.UnusedBed)
         .RuleFor(r => r.AvailableBed, (f, r) => r.UnusedBed == 6 ? false : f.Random.Bool())
         .RuleFor(a => a.Type, f => request.Type)
         .RuleFor(a => a.Status, f => f.PickRandom<RoomStatus>())
         .RuleFor(a => a.Width, f => f.Random.Float(1, 10))
         .RuleFor(a => a.Height, f => f.Random.Float(1, 10))
         .RuleFor(a => a.Length, f => f.Random.Float(1, 10))
         .RuleFor(a => a.Block, f => block)
         .RuleFor(a => a.Package, f => package)
         .Generate(request.TotalRoom);

        foreach (var room in DefaultRoom)
        {
            await _roomRepository.CreateAsync(room);
        }
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }

    public List<Room> DefaultRoom
    {
        get
        {
            int counter = 1;
            return new Faker<Room>()
         //.RuleFor(a => a.Name, f => f.PickRandom(Enumerable.Range(1, 10).Select(i => $"Room {i}").ToArray()))
         .RuleFor(a => a.Name, r => $"Room {counter++}")
         .RuleFor(a => a.Capacity, r => r.Random.Number(1, 30))
         .RuleFor(a => a.AvailableBed, r => r.Random.Bool())
         .RuleFor(a => a.TotalBed, r => 6)
         .RuleFor(r => r.UnusedBed, r => r.Random.Number(0, 6))
         .RuleFor(r => r.UserBed, (f, r) => 6 - r.UnusedBed)
         .RuleFor(r => r.AvailableBed, (f, r) => r.UnusedBed == 6 ? false : f.Random.Bool())
         .RuleFor(a => a.Type, f => f.PickRandom<TypeEnum>())
         .RuleFor(a => a.Status, f => f.PickRandom<RoomStatus>())
         .RuleFor(a => a.Width, f => f.Random.Float(1, 10))
         .RuleFor(a => a.Height, f => f.Random.Float(1, 10))
         .RuleFor(a => a.Length, f => f.Random.Float(1, 10))
         .Generate(6);
        }
    }
}
