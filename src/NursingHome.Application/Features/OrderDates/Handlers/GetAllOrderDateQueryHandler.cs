using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.OrderDates.Models;
using NursingHome.Application.Features.OrderDates.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.OrderDates.Handlers;
public record GetAllOrderDateQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllOrderDateQuery, PaginatedResponse<OrderDateGetAllResponse>>
{
    private readonly IGenericRepository<OrderDate> _orderDateRepository = unitOfWork.Repository<OrderDate>();
    public async Task<PaginatedResponse<OrderDateGetAllResponse>> Handle(GetAllOrderDateQuery request, CancellationToken cancellationToken)
    {
        var orderDates = await _orderDateRepository
           .FindAsync<OrderDateGetAllResponse>(
               request.PageIndex,
               request.PageSize,
               request.GetExpressions(),
               request.GetOrder(),
               cancellationToken);

        return await orderDates.ToPaginatedResponseAsync();
    }
}
