using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Features.Rooms.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class GetRoomByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetRoomByIdQuery, RoomResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    public async Task<RoomResponse> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.FindByAsync<RoomResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($"Package Type Have Id {request.Id} Is Not Found");
        return room;
    }
}
