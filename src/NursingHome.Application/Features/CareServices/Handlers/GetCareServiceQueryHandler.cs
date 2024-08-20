using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.CareServices.Models;
using NursingHome.Application.Features.CareServices.Queries;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.CareServices.Handlers;
internal class GetCareServiceQueryHandler(
     IUnitOfWork unitOfWork
    ) : IRequestHandler<GetCareServiceQuery, CareServiceResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    public async Task<CareServiceResponse> Handle(GetCareServiceQuery request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.FindByAsync<BaseRoomResponse>(_ => _.Id == request.RoomId)
         ?? throw new NotFoundException($"Room Have Id {request.RoomId} Is Not Found");

        var elder = await _elderRepository.FindAsync<ElderCareServiceResponse>(_ => _.RoomId == request.RoomId
        && _.OrderDetails.Any(o => o.Order.Status == OrderStatus.Paid && o.OrderDates.Any(od => od.Date == request.Date)));

        return new CareServiceResponse
        {
            Room = room,
            Elders = elder
        };
    }
}
