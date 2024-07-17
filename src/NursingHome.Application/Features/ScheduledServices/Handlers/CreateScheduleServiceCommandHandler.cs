using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ScheduledServices.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ScheduledServices.Handlers;
internal class CreateScheduleServiceCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateScheduleServiceCommand, MessageResponse>
{
    private readonly IGenericRepository<OrderDetail> _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<ScheduledService> _scheduledServiceRepository = unitOfWork.Repository<ScheduledService>();
    public async Task<MessageResponse> Handle(CreateScheduleServiceCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            var nextMonth = currentDate.AddMonths(1);

            var listOrderDetails = await _orderDetailRepository.FindAsync(
                expression: _ => _.Status == OrderDetailStatus.Repeatable,
                includeFunc: _ => _.Include(x => x.OrderDates).Include(x => x.Order));

            var groupedOrderDetails = new Dictionary<Guid, List<ScheduledServiceDetail>>();

            foreach (var item in listOrderDetails)
            {
                var userId = item.Order.UserId;

                if (!groupedOrderDetails.ContainsKey(userId))
                {
                    groupedOrderDetails[userId] = new List<ScheduledServiceDetail>();
                }

                var scheduledServiceDetail = new ScheduledServiceDetail
                {
                    ElderId = item.ElderId,
                    ServicePackageId = item.ServicePackageId,
                    ScheduledTimes = new HashSet<ScheduledTime>(),
                    Type = item.Type
                };

                if (item.Type == OrderDetailType.RecurringDay)
                {
                    foreach (var orderDate in item.OrderDates)
                    {
                        if (orderDate.Date.Month == currentDate.Month && orderDate.Date.Year == currentDate.Year)
                        {
                            scheduledServiceDetail.ScheduledTimes.Add(new ScheduledTime
                            {
                                Date = orderDate.Date.AddMonths(1)
                            });
                        }
                    }
                }
                else if (item.Type == OrderDetailType.RecurringWeeks)
                {
                    var daysOfWeekInList = item.OrderDates
                        .Select(orderDate => orderDate.Date.DayOfWeek)
                        .Distinct()
                        .OrderBy(day => day)
                        .ToList();

                    foreach (var dayOfWeek in daysOfWeekInList)
                    {
                        var datesInNextMonth = GetDatesInNextMonth(dayOfWeek);
                        foreach (var date in datesInNextMonth)
                        {
                            if (date.Month == nextMonth.Month && date.Year == nextMonth.Year)
                            {
                                scheduledServiceDetail.ScheduledTimes.Add(new ScheduledTime
                                {
                                    Date = date
                                });
                            }
                        }
                    }
                }

                if (scheduledServiceDetail.ScheduledTimes.Any())
                {
                    groupedOrderDetails[userId].Add(scheduledServiceDetail);
                }
            }

            foreach (var item in groupedOrderDetails)
            {
                var scheduledService = new ScheduledService
                {
                    Name = $"Gói dịch vụ gia hạn Tháng {nextMonth.Month}",
                    UserId = item.Key,
                    ScheduledServiceDetails = item.Value,
                    Status = ScheduledServiceStatus.None
                };
                await _scheduledServiceRepository.CreateAsync(scheduledService);
            }

            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {

        }
        return new MessageResponse(Resource.CreatedSuccess);
    }
    private List<DateOnly> GetDatesInNextMonth(DayOfWeek dayOfWeek)
    {
        DateTime nextMonth = DateTime.Now.AddMonths(1);
        int year = nextMonth.Year;
        int month = nextMonth.Month;

        int daysInMonth = DateTime.DaysInMonth(year, month);
        List<DateOnly> specificDays = new List<DateOnly>();

        for (int day = 1; day <= daysInMonth; day++)
        {
            DateOnly date = new DateOnly(year, month, day);
            if (date.DayOfWeek == dayOfWeek)
            {
                specificDays.Add(date);
            }
        }
        return specificDays;
    }
}
