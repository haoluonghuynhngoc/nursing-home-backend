using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.CareServices.Models;
using NursingHome.Application.Features.CareServices.Queries;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.CareServices.Handlers;
internal sealed class GetCareServiceQueryHandler(
     IUnitOfWork unitOfWork
    ) : IRequestHandler<GetCareServiceQuery, CareServiceResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    public async Task<CareServiceResponse> Handle(GetCareServiceQuery request, CancellationToken cancellationToken)
    {
        // nếu dịch vụ chưa được thành toán thì khongo được lây ra 
        var room = await _roomRepository.FindByAsync(
                expression: _ => _.Id == request.RoomId,
                includeFunc: _ => _.Include(x => x.Elders)
                .ThenInclude(_ => _.OrderDetails)
                .ThenInclude(_ => _.OrderDates)
                .Include(_ => _.Elders)
                .ThenInclude(_ => _.OrderDetails)
                .ThenInclude(_ => _.ServicePackage)
                .Include(_ => _.Elders)
                .ThenInclude(_ => _.User))
             ?? throw new NotFoundException($"Room Have Id {request.RoomId} Is Not Found");

        var elderResponse = new HashSet<CareServiceElderResponse>();
        // chưa sửa user bị null ở đây 
        foreach (var item in room.Elders)
        {
            var elder = item.Adapt<CareServiceElderResponse>();
            elder.OrderDetails = item.OrderDetails
               .Where(_ => _.OrderDates.Any(o => o.Date == request.Date) && _.Order.Status == OrderStatus.Paid)
               .Select(_ => _.Adapt<CareServiceOrderDetailResponse>())
               .ToHashSet();
            elderResponse.Add(elder);
        }

        return new CareServiceResponse
        {
            Room = room.Adapt<BaseRoomResponse>(),
            Elders = elderResponse
        };
    }
}
