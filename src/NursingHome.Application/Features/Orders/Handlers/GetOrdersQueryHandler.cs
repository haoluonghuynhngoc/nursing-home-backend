using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Orders.Models;
using NursingHome.Application.Features.Orders.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class GetOrdersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrdersQuery, PaginatedResponse<OrderResponse>>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task<PaginatedResponse<OrderResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository
            .FindAsync<OrderResponse>(
                request.PageIndex,
                request.PageSize,
                request.GetExpressions(),
                request.GetOrder(),
                cancellationToken);

        return await orders.ToPaginatedResponseAsync();
    }
}
