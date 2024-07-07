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

    public TaskSchedulerOrder(IUnitOfWork unitOfWork, ILogger<TaskSchedulerOrder> logger)
    {
        _unitOfWork = unitOfWork;
        _contractRepository = unitOfWork.Repository<Contract>();
        _orderRepository = unitOfWork.Repository<Order>();
        _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
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
                var notificationDate = contract.EndDate.AddDays(-3);
                if (notificationDate == currentDate)
                {
                    // gửi email thông báo sắp hết hạn
                }

                if (contract.StartDate == currentDate)
                {
                    contract.Status = ContractStatus.Valid;
                    // gửi mail thông báo hợp đồng đã được kích hoạt
                }
                //if (contract.StartDate < currentDate && contract.EndDate > currentDate)
                //{
                //    // thực hiện 1 vài cái gì đó 
                //}
                if (contract.EndDate <= currentDate)
                {
                    contract.Status = ContractStatus.Expired;
                    // gửi email thông báo hợp đồng đã hết hạn
                }

                await _contractRepository.UpdateAsync(contract);
                await _unitOfWork.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking contract expiration.");
        }
    }

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
                    if (orderDetail.OrderDates.All(orderDate => orderDate.Date < currentDate))
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
                expression: _ => _.Status != OrderDetailStatus.Finalized,
                includeFunc: _ => _.Include(x => x.OrderDates).Include(x => x.Order));

            // Nhóm các OrderDetail theo UserId
            var groupedOrderDetails = new Dictionary<Guid, List<OrderDetail>>();

            foreach (var item in listOrderDetails)
            {
                if (item.Status == OrderDetailStatus.Repeatable)
                {
                    // gom dữ liệu theo userId theo key value  
                    var userId = item.Order.UserId;
                    if (!groupedOrderDetails.ContainsKey(userId))
                    {
                        groupedOrderDetails[userId] = new List<OrderDetail>();
                    }

                    var orderDetail = new OrderDetail();
                    orderDetail.Price = item.Price;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.Type = item.Type;
                    orderDetail.Status = item.Status;
                    orderDetail.ServicePackageId = item.ServicePackageId;
                    orderDetail.ElderId = item.ElderId;
                    orderDetail.OrderDates = new List<OrderDate>();

                    foreach (var orderDate in item.OrderDates)
                    {
                        // check đơn hàng này có phải của hơn hàng của tháng này không nếu phải thì thêm vào đơn cho tháng sau
                        if (orderDate.Date.Month == currentDate.Month)
                        {
                            orderDetail.OrderDates.Add(new OrderDate()
                            {
                                Date = orderDate.Date.AddMonths(1),
                                Status = OrderDateStatus.InComplete
                            });
                        }
                    }
                    groupedOrderDetails[userId].Add(orderDetail);
                }
            }

            // Tạo các đơn hàng mới cho từng người dùng
            foreach (var iteam in groupedOrderDetails)
            {
                var order = new Order
                {
                    UserId = iteam.Key,
                    OrderDetails = iteam.Value
                };
                await _orderRepository.CreateAsync(order);
            }
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating renewal notifications.");
        }
    }

    public void PrintNow()
    {
        logger.LogInformation($"Order Test: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}");
    }
    public void PrintTimeNow()
    {
        logger.LogInformation($"Time Test: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}");
    }
}