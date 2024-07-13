using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.CareServices.Models;
using NursingHome.Application.Features.CareServices.Queries;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.CareServices.Handlers;
internal sealed class GetCareServiceQueryHandler(
     IUnitOfWork unitOfWork
    ) : IRequestHandler<GetCareServiceQuery, CareServiceResponse>
{
    private readonly IGenericRepository<Room> _roomRepository = unitOfWork.Repository<Room>();
    public async Task<CareServiceResponse> Handle(GetCareServiceQuery request, CancellationToken cancellationToken)
    {

        var room = await _roomRepository.FindByAsync(
                expression: _ => _.Id == request.RoomId,
                includeFunc: _ => _.Include(x => x.Elders)
                .ThenInclude(_ => _.OrderDetails)
                .ThenInclude(_ => _.OrderDates)
                .Include(_ => _.Elders)
                .ThenInclude(_ => _.OrderDetails)
                .ThenInclude(_ => _.ServicePackage))
             ?? throw new NotFoundException($"Room Have Id {request.RoomId} Is Not Found");

        var elderResponse = new HashSet<CareServiceElderResponse>();

        foreach (var item in room.Elders)
        {
            var elder = item.Adapt<CareServiceElderResponse>();
            elder.OrderDetails = item.OrderDetails
                .Where(_ => _.OrderDates.Any(o => o.Date == request.Date))
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
