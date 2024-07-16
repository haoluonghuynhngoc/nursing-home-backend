using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.OrderDates.Models;
using NursingHome.Application.Features.OrderDates.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.OrderDates.Handlers;
internal class GetOrderDateByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetOrderDateByIdQuery, OrderDateResponse>
{
    private readonly IGenericRepository<OrderDate> _orderDateRepository = unitOfWork.Repository<OrderDate>();
    public async Task<OrderDateResponse> Handle(GetOrderDateByIdQuery request, CancellationToken cancellationToken)
    {
        var orderDate = await _orderDateRepository.FindByAsync<OrderDateResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($"Order Date Have Id {request.Id} Is Not Found");
        return orderDate;
    }
}
