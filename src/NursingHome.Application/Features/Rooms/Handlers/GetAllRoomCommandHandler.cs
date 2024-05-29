using LinqKit;
using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Features.Rooms.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Rooms.Handlers;
internal sealed class GetAllRoomCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllRoomCommand, PaginatedResponse<RoomResponse>>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    public async Task<PaginatedResponse<RoomResponse>> Handle(GetAllRoomCommand request, CancellationToken cancellationToken)
    {

        var expression = request.GetExpressions();
        expression = expression.Or(r => r.Type == request.Type)
            .Or(r => r.AvailableBed == request.AvailableBed);
        var listRoom = await _roomRepository.FindAsync<RoomResponse>(
               pageIndex: request.PageIndex,
               pageSize: request.PageSize,
               expression,
               orderBy: request.GetOrder(),
               cancellationToken: cancellationToken
               );
        return await listRoom.ToPaginatedResponseAsync();
    }
}
//x => x.OrderBy(x => x.Id)