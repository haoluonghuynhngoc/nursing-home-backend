using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
    public async Task<MessageResponse> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        if (!await _blockRepository.ExistsByAsync(_ => _.Id == request.BlockId))
        {
            throw new NotFoundException(nameof(Block), request.BlockId);
        }

        var room = await _roomRepository.FindByAsync(
            expression: _ => _.Id == request.Id, includeFunc: _ => _.Include(x => x.Elders))
             ?? throw new NotFoundException(nameof(Room), request.Id);

        //if (await _roomRepository.ExistsByAsync(_ => _.Id != request.Id && (_.Name == request.Name && _.BlockId == room.BlockId)))
        //{
        //    throw new ConflictException($"Room Have Name {request.Name} In Block Have Block ID Is {room.BlockId}");
        //}
        if (await _roomRepository.ExistsByAsync(_ => _.Id != request.Id && _.Name == request.Name && _.BlockId == request.BlockId))
        {
            throw new ConflictException($"Room Have Name {request.Name} In Block Have Block ID Is {request.BlockId}");
        }
        Console.WriteLine("Room Name: " + room.Elders);
        if (request.NursingPackageId != null)
        {
            if (!await _nursingPackageRepository.ExistsByAsync(_ => _.Id == request.Id))
            {
                throw new FieldResponseException(612, "Nursing Package Is Null");
            }
            if (room.TotalElder > 0)
            {
                throw new FieldResponseException(613, "The Room Is Already Occupied So It Is Not Possible To Change The Service Package");
            }
        }

        request.Adapt(room);
        await _roomRepository.UpdateAsync(room);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
