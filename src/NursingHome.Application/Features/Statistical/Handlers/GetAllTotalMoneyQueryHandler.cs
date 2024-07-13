using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Statistical.Models;
using NursingHome.Application.Features.Statistical.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Statistical.Handlers;
internal sealed class GetAllTotalMoneyQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllTotalMoneyQuery, TotalMoneyResponse>
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    public async Task<TotalMoneyResponse> Handle(GetAllTotalMoneyQuery request, CancellationToken cancellationToken)
    {

        var listOrder = await _orderRepository.FindAsync(_ => _.Status == OrderStatus.Paid,
            includeFunc: _ => _.Include(x => x.OrderDetails).ThenInclude(_ => _.ServicePackage)
            .Include(x => x.OrderDetails).ThenInclude(_ => _.Contract));

        var amountNursingpackage = (double)listOrder.SelectMany(order => order.OrderDetails)
            .Where(orderDetail => orderDetail.Contract != null)
            .Sum(orderDetail => orderDetail.Price);

        var amountServicepackage = (double)listOrder.SelectMany(order => order.OrderDetails)
            .Where(orderDetail => orderDetail.ServicePackage != null)
            .Sum(orderDetail => orderDetail.Price);

        return new TotalMoneyResponse
        {
            TotalMoney = listOrder.Sum(_ => _.Amount),
            TotalMoneyNursingPackage = amountNursingpackage,
            TotalMoneyServicePackage = amountServicepackage
        };
    }
}
