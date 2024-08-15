using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.Statistical.Models;
using NursingHome.Application.Features.Statistical.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Statistical.Handlers;
internal sealed class GetAllTotalInYearQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllTotalInYearQuery, Dictionary<int, StatisticalResponse>>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();

    public async Task<Dictionary<int, StatisticalResponse>> Handle(GetAllTotalInYearQuery request, CancellationToken cancellationToken)
    {
        //Dictionary<int, StatisticalResponse> statisticalResponse = new();
        //for (var i = 1; i <= 12; i++)
        //{
        //    statisticalResponse.Add(i, new StatisticalResponse());
        //}
        var statisticalResponse = Enumerable.Range(1, 12).ToDictionary(i => i, i => new StatisticalResponse());

        var elders = await _elderRepository.FindAsync(
            expression: e => e.CreatedAt != null && e.State == StateType.Active && e.CreatedAt.Value.Year == request.Year);

        var users = await _userRepository.FindAsync(
            expression: u => u.CreatedAt != null && u.CreatedAt.Value.Year == request.Year);

        var orders = await _orderRepository.FindAsync(
            expression: o => o.CreatedAt != null && o.CreatedAt.Value.Year == request.Year && o.Status == OrderStatus.Paid,
            includeFunc: o => o.Include(_ => _.OrderDetails).ThenInclude(_ => _.ServicePackage)
            .Include(x => x.OrderDetails).ThenInclude(_ => _.Contract));

        elders.ToList().ForEach(elder =>
        {
            if (elder.CreatedAt.HasValue)
            {
                statisticalResponse[elder.CreatedAt.Value.Month].Elder++;
            }
        });
        users.ToList().ForEach(user =>
        {
            if (user.CreatedAt.HasValue)
            {
                statisticalResponse[user.CreatedAt.Value.Month].User++;
            }
        });
        orders.ToList().ForEach(order =>
        {
            if (order.CreatedAt.HasValue)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    if (orderDetail.ServicePackage != null)
                    {
                        statisticalResponse[order.CreatedAt.Value.Month].ServicePackage += orderDetail.Price;
                    }
                    if (orderDetail.Contract != null)
                    {
                        statisticalResponse[order.CreatedAt.Value.Month].NursingPackage += orderDetail.Price;
                    }
                }
            }
        });
        return statisticalResponse;
    }
}
