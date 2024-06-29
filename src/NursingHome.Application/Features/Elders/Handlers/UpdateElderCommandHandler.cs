using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Application.Features.Elders.Handlers;
internal class UpdateElderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();

    public async Task<MessageResponse> Handle(UpdateElderCommand request, CancellationToken cancellationToken)
    {
        if (await _elderRepository.ExistsByAsync(x => x.Id != request.Id && x.CCCD == request.CCCD))
        {
            throw new ConflictException($"Elder Have CCCD is {request.CCCD} In DataBase");
        }

        if (!await _roomRepository.ExistsByAsync(_ => _.Id == request.RoomId, cancellationToken))
        {
            throw new NotFoundException(nameof(Room), request.RoomId);
        }

        if (!await _userRepository.ExistsByAsync(_ => _.Id == request.UserId, cancellationToken))
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        var room = await _roomRepository.FindByAsync(x => x.Id == request.RoomId
              , includeFunc: _ => _.Include(x => x.NursingPackage), cancellationToken: cancellationToken);
        if (room?.NursingPackageId == null)
        {
            throw new FieldResponseException(605, "Room Not Have Package");
        }
        if (room?.NursingPackageId != request.NursingPackageId)
        {
            throw new FieldResponseException(606, $"This Room Does Not Contain A Nursing Package With Id {request.NursingPackageId}");
        }
        var elder = await _elderRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (elder is null)
        {
            throw new NotFoundException(nameof(Elder), request.Id);
        }

        request.Adapt(elder);

        await _elderRepository.UpdateAsync(elder);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);

    }
}

