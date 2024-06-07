using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Features.Rooms.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class GetAllRoomQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllRoomQuery, PaginatedResponse<RoomResponse>>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    public async Task<PaginatedResponse<RoomResponse>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
        var listRoom = await _roomRepository.FindAsync<RoomResponse>(
               pageIndex: request.PageIndex,
               pageSize: request.PageSize,
               request.GetExpressions(),
               orderBy: request.GetOrder(),
               cancellationToken: cancellationToken
               );
        return await listRoom.ToPaginatedResponseAsync();
    }
}
