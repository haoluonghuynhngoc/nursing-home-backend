using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.OrderDetails.Models;
using NursingHome.Application.Features.OrderDetails.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.OrderDetails.Handlers;
internal class GetAllDateServicePackageRegisterHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllDateServicePackageRegister, List<DateOrderRegisterResponse>>
{
    private readonly IGenericRepository<OrderDetail> _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
    public async Task<List<DateOrderRegisterResponse>> Handle(GetAllDateServicePackageRegister request, CancellationToken cancellationToken)
    {
        var listDate = new List<DateOrderRegisterResponse>();

        var listOrderDetail = await _orderDetailRepository.FindAsync(_ => _.ElderId == request.ElderId
        && _.ServicePackageId == request.ServicePackageId
        && _.Status != OrderDetailStatus.Finalized, includeFunc: _ => _.Include(x => x.OrderDates));
        foreach (var orderDetail in listOrderDetail)
        {
            if (orderDetail.Type == OrderDetailType.One_Time)
            {
                orderDetail.OrderDates.Select(_ => _.Date).ToList().ForEach(date =>
                {
                    listDate.Add(new DateOrderRegisterResponse
                    {
                        Date = date
                    });
                });
            }
            if (orderDetail.Type == OrderDetailType.RecurringDay)
            {
                orderDetail.OrderDates.Select(_ => _.Date).ToList().ForEach(date =>
                {
                    listDate.Add(new DateOrderRegisterResponse
                    {
                        DayOfMonth = date.Day
                    });
                });
            }
            if (orderDetail.Type == OrderDetailType.RecurringWeeks)
            {
                orderDetail.OrderDates.Select(_ => _.Date).ToList().ForEach(date =>
                {
                    listDate.Add(new DateOrderRegisterResponse
                    {
                        DayOfWeek = date.DayOfWeek
                    });
                });
            }
        }
        return listDate;

    }
}
