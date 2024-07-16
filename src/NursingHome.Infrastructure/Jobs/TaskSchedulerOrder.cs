using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Jobs;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Jobs;
public class TaskSchedulerOrder : ITaskSchedulerOrder
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TaskSchedulerOrder> logger;
    private readonly IGenericRepository<Contract> _contractRepository;
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
    private readonly IGenericRepository<ScheduledService> _scheduledServiceRepository;

    public TaskSchedulerOrder(IUnitOfWork unitOfWork, ILogger<TaskSchedulerOrder> logger)
    {
        _unitOfWork = unitOfWork;
        _contractRepository = unitOfWork.Repository<Contract>();
        _orderRepository = unitOfWork.Repository<Order>();
        _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
        _scheduledServiceRepository = unitOfWork.Repository<ScheduledService>();
        this.logger = logger;
    }
    public async Task CheckContractExpirationAsync()
    {
        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            var listContracts = await _contractRepository.FindAsync(
                expression: _ => _.Status != ContractStatus.Expired && _.Status != ContractStatus.Cancelled);
            foreach (var contract in listContracts)
            {
                if (contract.StartDate == currentDate)
                {
                    contract.Status = ContractStatus.Valid;
                    // gửi mail thông báo hợp đồng đã được kích hoạt
                    // gửi thông báo qua app
                }

                var notificationDate = contract.EndDate;
                if (notificationDate.AddDays(-10) == currentDate)
                {
                    // gửi email thông báo sắp hết hạn
                    // gửi thông báo qua app
                }
                if (contract.EndDate <= currentDate)
                {
                    contract.Status = ContractStatus.Expired;
                    // gửi email thông báo hợp đồng đã hết hạn
                    // gửi thông báo qua app
                }

                //if (contract.StartDate < currentDate && contract.EndDate > currentDate)
                //{
                //    // thực hiện 1 vài cái gì đó 
                //}

                await _contractRepository.UpdateAsync(contract);
                await _unitOfWork.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking contract expiration.");
        }
    }
    public async Task CheckOrderExpirationAsync()
    {
        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            // check cai nay 
            var listOrders = await _orderRepository.FindAsync(
                expression: _ => _.Status == OrderStatus.UnPaid
                || _.Status == OrderStatus.Failed, includeFunc: _ => _.Include(x => x.OrderDetails)
                .ThenInclude(x => x.OrderDates)); // include tiếp vào thằng ở trong luôn 

            foreach (var order in listOrders)
            {
                if (order.DueDate < currentDate)
                {
                    order.Status = OrderStatus.OverDue;
                    foreach (var orderDetail in order.OrderDetails)
                    {
                        orderDetail.Status = OrderDetailStatus.Finalized;
                        foreach (var orderDate in orderDetail.OrderDates)
                        {
                            orderDate.Status = OrderDateStatus.NotPerformed;
                        }
                    }
                }
                await _orderRepository.UpdateAsync(order);
            }
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking order expiration.");
        }
    }

    // Hàm này chưa kiểm tra nên chưa cho nó vào db 
    // Lỗi logic có thể nếu tháng sau không có ngày thì chưa lập lại được ngày đó thì có thể nó hủy luôn
    // Trường hợp tốt nhât là thêm field status nếu ngày chưa lập lại thì thêm
    public async Task CheckOrderDetailExpirationAsync()
    {
        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            var listOrderDetails = await _orderDetailRepository.FindAsync(
                expression: _ => _.Status != OrderDetailStatus.Finalized, includeFunc: _ => _.Include(x => x.OrderDates));

            foreach (var orderDetail in listOrderDetails)
            {
                // Đi từ cao tới thấp Repeatable -> NonRepeatable -> Finalized
                if (orderDetail.Status == OrderDetailStatus.NonRepeatable)
                {
                    // Kiểm tra nếu không có ngày nào trong OrderDates lớn hơn currentDate thì đổi trạng thái
                    if (orderDetail.OrderDates != null && orderDetail.OrderDates.All(orderDate => orderDate.Date < currentDate))
                    {
                        orderDetail.Status = OrderDetailStatus.Finalized;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking order detail expiration.");
        }
    }

    // Chưa kiểm tra hàm này 
    // hiển thị lên thông báo để người dùng có thể gia hạn gói dịch vụ
    // Chỉ hiện thị những gói dịch vụ cho tháng sau chứ không được vược quá 2 tháng
    public async Task CreateDisplayRenewalNotificationAsync()
    {
        try
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

            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating renewal notifications.");
        }
    }

    //// Lấy ngày hợp lệ của tháng sau
    //public bool IsNextMonthValidDate(DateOnly currentDate)
    //{
    //    try
    //    {
    //        var firstDayOfCurrentMonth = new DateOnly(currentDate.Year, currentDate.Month, 1);
    //        var firstDayOfNextMonth = firstDayOfCurrentMonth.AddMonths(1);
    //        var lastDayOfNextMonth = new DateOnly(firstDayOfNextMonth.Year, firstDayOfNextMonth.Month, DateTime.DaysInMonth(firstDayOfNextMonth.Year, firstDayOfNextMonth.Month));
    //        return currentDate.Day <= lastDayOfNextMonth.Day;
    //    }
    //    catch (ArgumentOutOfRangeException)
    //    {
    //        return false;
    //    }
    //}

}