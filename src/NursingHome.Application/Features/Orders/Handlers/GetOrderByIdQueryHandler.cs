using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Orders.Models;
using NursingHome.Application.Features.Orders.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Orders.Handlers;
internal class GetOrderByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrderByIdQuery, OrderResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByAsync<OrderResponse>(x => x.Id == request.Id, cancellationToken);

        if (order == null)
        {
            throw new NotFoundException(nameof(Order), request.Id);
        }

        return order;
    }
}
