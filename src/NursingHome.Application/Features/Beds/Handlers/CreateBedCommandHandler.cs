using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Beds.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Beds.Handlers;
internal sealed class CreateBedCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateBedCommand, MessageResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    private readonly IGenericRepository<Bed> _bedRepository = unitOfWork.Repository<Bed>();
    public async Task<MessageResponse> Handle(CreateBedCommand request, CancellationToken cancellationToken)
    {
        var block = await _roomRepository.FindByAsync(x => x.Id == request.RoomId)
          ?? throw new NotFoundException($"Bed Have Id {request.RoomId} Is Not Found");
        var bed = new Bed
        {
            RoomId = request.RoomId,
            Status = request.Status
        };
        await _bedRepository.CreateAsync(bed);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
