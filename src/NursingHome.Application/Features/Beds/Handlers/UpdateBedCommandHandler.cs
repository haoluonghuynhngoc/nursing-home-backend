using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Beds.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Beds.Handlers;
internal sealed class UpdateBedCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateBedCommand, MessageResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Bed> _bedRepository = unitOfWork.Repository<Bed>();
    public async Task<MessageResponse> Handle(UpdateBedCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.FindByAsync(x => x.Id == request.RoomId)
        ?? throw new NotFoundException($"Room Have Id {request.RoomId} Is Not Found");

        var bed = await _bedRepository.FindByAsync(
            expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Bed Have Id {request.Id} Is Not Found");

        request.Adapt(bed);
        await _bedRepository.UpdateAsync(bed);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
