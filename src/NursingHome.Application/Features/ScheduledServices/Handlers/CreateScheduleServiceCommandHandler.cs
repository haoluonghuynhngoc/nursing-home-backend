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

        var currentDate = DateOnly.FromDateTime(DateTime.Now);

        var listOrderDetails = await _orderDetailRepository.FindAsync(
            expression: _ => _.Status == OrderDetailStatus.Repeatable,
            includeFunc: _ => _.Include(x => x.OrderDates).Include(x => x.Order));

        // Nhóm các ScheduledServiceDetail theo UserId
        var groupedOrderDetails = new Dictionary<Guid, List<ScheduledServiceDetail>>();

        foreach (var item in listOrderDetails)
        {
            var userId = item.Order.UserId;

            if (!groupedOrderDetails.ContainsKey(userId))
            {
                groupedOrderDetails[userId] = new List<ScheduledServiceDetail>();
            }

            var scheduledServiceDetail = new ScheduledServiceDetail();
            scheduledServiceDetail.ElderId = item.ElderId;
            scheduledServiceDetail.ServicePackageId = item.ServicePackageId;
            scheduledServiceDetail.ScheduledTimes = new HashSet<ScheduledTime>();
            scheduledServiceDetail.Type = item.Type;
            // ScheduledService
            foreach (var orderDate in item.OrderDates)
            {
                // check đơn hàng này có phải của tháng hiện tại không, nếu phải thì thêm vào đơn cho tháng sau
                if (orderDate.Date.Month == currentDate.Month && orderDate.Date.Year == currentDate.Year)
                {
                    scheduledServiceDetail.ScheduledTimes.Add(new ScheduledTime()
                    {
                        // sai ở đây nó chỉ cộng cho tháng nào phù hợp chứ khôgn đúng ngày 
                        Date = orderDate.Date.AddMonths(1)
                    });
                }
            }

            // Chỉ thêm ScheduledServiceDetail nếu có ScheduledTimes
            if (scheduledServiceDetail.ScheduledTimes.Any())
            {
                groupedOrderDetails[userId].Add(scheduledServiceDetail);
            }

        }

        // Tạo các gói dịch vụ theo ngày lặp lại cho từng người dùng
        foreach (var item in groupedOrderDetails)
        {
            var scheduledService = new ScheduledService
            {
                Name = $"Gói dịch vụ gia hạn Tháng {currentDate.AddMonths(1).Month}",
                UserId = item.Key,
                ScheduledServiceDetails = item.Value,
                Status = ScheduledServiceStatus.None
            };
            await _scheduledServiceRepository.CreateAsync(scheduledService);
        }

        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }

}
