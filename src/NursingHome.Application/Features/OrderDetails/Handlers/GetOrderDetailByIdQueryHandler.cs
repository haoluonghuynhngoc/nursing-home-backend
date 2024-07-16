using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.OrderDetails.Models;
using NursingHome.Application.Features.OrderDetails.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.OrderDetails.Handlers;
internal class GetOrderDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetOrderDetailByIdQuery, OrderDetailResponse>
{
    private readonly IGenericRepository<OrderDetail> _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
    public async Task<OrderDetailResponse> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderDetailRepository.FindByAsync<OrderDetailResponse>(x => x.Id == request.Id)
          ?? throw new NotFoundException($"Order Detail Have Id {request.Id} Is Not Found");
        return orderDetail;
    }
}
