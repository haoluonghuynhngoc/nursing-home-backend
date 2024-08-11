using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Jobs;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using System.Text.Json;

namespace NursingHome.Infrastructure.Jobs;
public class TaskSchedulerOrder : ITaskSchedulerOrder
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TaskSchedulerOrder> logger;
    private readonly IGenericRepository<Contract> _contractRepository;
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
    private readonly IGenericRepository<ScheduledService> _scheduledServiceRepository;
    private readonly IGenericRepository<Appointment> _appointmentServiceRepository;
    private readonly IGenericRepository<OrderDate> _orderDateRepository;
    private readonly INotifier _notifier;
    public TaskSchedulerOrder(IUnitOfWork unitOfWork, INotifier INotifier, ILogger<TaskSchedulerOrder> logger)
    {
        _notifier = INotifier;
        _unitOfWork = unitOfWork;
        _contractRepository = unitOfWork.Repository<Contract>();
        _orderRepository = unitOfWork.Repository<Order>();
        _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
        _scheduledServiceRepository = unitOfWork.Repository<ScheduledService>();
        _appointmentServiceRepository = unitOfWork.Repository<Appointment>();
        _orderDateRepository = unitOfWork.Repository<OrderDate>();
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
                    SendNotification(contract.Id, $"Thông Báo Hợp Đồng Ngày {currentDate:dd/MM/yyyy}",
                       $"Hợp đồng có hiệu lực: Hợp đồng có mã {contract.Name} có hiệu lực vào ngày {currentDate:dd/MM/yyyy}.",
                     contract.UserId, nameof(Contract), NotificationLevel.Information, CancellationToken.None);
                }

                var notificationDate = contract.EndDate;
                if (notificationDate.AddDays(-30) == currentDate)
                {
                    // gửi email thông báo sắp hết hạn
                    SendNotification(contract.Id, $"Thông Báo Hợp Đồng Ngày {currentDate:dd/MM/yyyy}",
                      $"Hợp đồng sắp hết hạn (cách 30 ngày): Bạn có muốn gia hạn hợp đồng có mã {contract.Name} sẽ hết hạn vào ngày {contract.EndDate:dd/MM/yyyy}",
                    contract.UserId, nameof(Contract), NotificationLevel.Information, CancellationToken.None);
                }
                if (contract.EndDate <= currentDate)
                {
                    contract.Status = ContractStatus.Expired;
                    // gửi email thông báo hợp đồng đã hết hạn
                    SendNotification(contract.Id, $"Thông Báo Hợp Đồng Ngày {currentDate:dd/MM/yyyy}",
                     $"Hợp đồng có mã {contract.Name} đã hết hạn vào ngày{currentDate:dd/MM/yyyy}.",
                   contract.UserId, nameof(Contract), NotificationLevel.Information, CancellationToken.None);
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
            var listOrders = await _orderRepository.FindAsync(
                expression: _ => _.Status == OrderStatus.UnPaid
                || _.Status == OrderStatus.Failed, includeFunc: _ => _.Include(x => x.OrderDetails)
                .ThenInclude(x => x.OrderDates)
                .AsNoTracking()); // Thêm AsNoTracking để tăng hiệu suất nếu không cần theo dõi các thay đổi

            foreach (var order in listOrders)
            {
                if (order.DueDate <= currentDate)
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
    public async Task CheckOrderDateStatusAsync()
    {
        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            var listOrderDates = await _orderDateRepository.FindAsync(_ => _.Status == OrderDateStatus.InComplete);

            foreach (var orderDate in listOrderDates)
            {
                if (orderDate.Date <= currentDate)
                {
                    orderDate.Status = OrderDateStatus.Missed;
                }
                await _orderDateRepository.UpdateAsync(orderDate);
            }
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while check order date status.");
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
                    if (orderDetail.OrderDates != null && orderDetail.OrderDates.All(orderDate => orderDate.Date < currentDate))
                    {
                        orderDetail.Status = OrderDetailStatus.Finalized;
                    }
                }
                await _orderDetailRepository.UpdateAsync(orderDetail);
            }
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking order detail expiration.");
        }
    }
    public async Task CheckOrderRepeatableAsync()
    {
        try
        {
            var currentDate = new DateTimeOffset(DateTime.Today);
            var listOrders = await _orderRepository.FindAsync(
                expression: _ => _.Status == OrderStatus.Paid, includeFunc: _ => _.Include(x => x.OrderDetails)
                .ThenInclude(x => x.OrderDates)
                .AsNoTracking());

            foreach (var order in listOrders)
            {
                if (order.CreatedAt != null || order.CreatedAt <= currentDate.AddDays(1))
                {
                    foreach (var orderDetail in order.OrderDetails)
                    {
                        // cuối tháng kiểm tra xem nó có lập lại không nếu lập rồi thì không cho lập lại nữa
                        if (orderDetail.IsRepeatable)
                        {
                            orderDetail.Status = OrderDetailStatus.NonRepeatable;
                        }
                    }
                }
                await _orderRepository.UpdateAsync(order);
            }
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while check order repeatable expiration.");
        }
    }
    public async Task RemoveDisplayRenewalNotificationForOrderAsync()
    {
        try
        {
            var scheduledService = await _scheduledServiceRepository.FindAsync(
                includeFunc: _ => _.Include(_ => _.ScheduledServiceDetails).ThenInclude(_ => _.ScheduledTimes));
            foreach (var item in scheduledService)
            {
                foreach (var detail in item.ScheduledServiceDetails)
                {
                    detail.ScheduledTimes.Clear();
                }
                item.ScheduledServiceDetails.Clear();
                await _scheduledServiceRepository.DeleteAsync(item);
            }
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while removing renewal notifications.");
        }
    }
    public async Task CreateDisplayRenewalNotificationAsync()
    {
        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            var nextMonth = currentDate.AddMonths(1);

            var listOrderDetails = await _orderDetailRepository.FindAsync(
                expression: _ => _.Status == OrderDetailStatus.Repeatable
                && _.Order.Status == OrderStatus.Paid,
                includeFunc: _ => _.Include(x => x.OrderDates).Include(x => x.Order)
                .Include(x => x.Elder).ThenInclude(e => e.Contracts));
            // check thời hạn servic packeg không được vượt quá  nursing package  không cho gợi ý 
            // Dictionary để nhóm dữ liệu theo UserId và gộp các ScheduledServiceDetail trùng lặp
            var groupedOrderDetails = new Dictionary<Guid, List<ScheduledServiceDetail>>();

            foreach (var item in listOrderDetails)
            {
                var userId = item.Order.UserId;

                // Nêu đã gợi ý lập lại thì lưu vào Db là đã lập lại
                item.IsRepeatable = true;

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
                            // Hàm mới chưa check 
                            foreach (var contract in item.Elder.Contracts)
                            {
                                if (contract.Status == ContractStatus.Valid)
                                {
                                    if (contract.EndDate < orderDate.Date.AddMonths(1))
                                    {
                                        scheduledServiceDetail.ScheduledTimes.Add(new ScheduledTime
                                        {
                                            Date = orderDate.Date.AddMonths(1)
                                        });
                                    }
                                }
                            }
                            // Hàm Cũ
                            //scheduledServiceDetail.ScheduledTimes.Add(new ScheduledTime
                            //{
                            //    Date = orderDate.Date.AddMonths(1)
                            //});
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
                                // Hàm mới chưa check 
                                foreach (var contract in item.Elder.Contracts)
                                {
                                    if (contract.Status == ContractStatus.Valid)
                                    {
                                        if (contract.EndDate < date)
                                        {
                                            scheduledServiceDetail.ScheduledTimes.Add(new ScheduledTime
                                            {
                                                Date = date
                                            });
                                        }
                                    }
                                }
                                // Hàm Cũ 
                                //scheduledServiceDetail.ScheduledTimes.Add(new ScheduledTime
                                //{
                                //    Date = date
                                //});
                            }
                        }
                    }
                }

                if (scheduledServiceDetail.ScheduledTimes.Any())
                {
                    groupedOrderDetails[userId].Add(scheduledServiceDetail);
                }
            }

            // Gộp các ScheduledServiceDetail trùng lặp
            var mergedServiceDetails = new List<ScheduledService>();

            foreach (var group in groupedOrderDetails)
            {
                var userId = group.Key;
                var details = group.Value;

                var groupedDetails = details
                    .GroupBy(detail => new { detail.ElderId, detail.ServicePackageId, detail.Type })
                    .Select(g => new ScheduledServiceDetail
                    {
                        ElderId = g.Key.ElderId,
                        ServicePackageId = g.Key.ServicePackageId,
                        Type = g.Key.Type,
                        ScheduledTimes = new HashSet<ScheduledTime>(g.SelectMany(detail => detail.ScheduledTimes))
                    })
                    .ToList();

                var scheduledService = new ScheduledService
                {
                    Name = $"Gói dịch vụ gia hạn Tháng {nextMonth.Month}",
                    UserId = userId,
                    ScheduledServiceDetails = groupedDetails,
                    Status = ScheduledServiceStatus.None
                };

                mergedServiceDetails.Add(scheduledService);
            }

            foreach (var scheduledService in mergedServiceDetails)
            {
                await _scheduledServiceRepository.CreateAsync(scheduledService);
            }

            await _unitOfWork.CommitAsync();

            // viết thông báo dịch vụ tháng sau ở đây
            foreach (var scheduledService in mergedServiceDetails)
            {
                SendNotification(scheduledService.Id, $"Thông Báo Đơn Hàng Ngày {currentDate:dd/MM/yyyy}",
                      $"Thông báo xác nhận đăng ký dịch vụ {scheduledService.Name} cho tháng {nextMonth.Month} Năm {nextMonth.Year}",
                    scheduledService.UserId, nameof(ScheduledService), NotificationLevel.Information, CancellationToken.None);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating renewal notifications.");
        }
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

    public async Task CheckAppointmentExpirationAsync()
    {
        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            var listAppointment = await _appointmentServiceRepository.FindAsync(
                expression: _ => _.Status == AppointmentStatus.Pending || _.Status == AppointmentStatus.Approved);
            foreach (var appointment in listAppointment)
            {
                if (appointment.Date < currentDate)
                {
                    appointment.Status = AppointmentStatus.Cancelled;
                }

                await _appointmentServiceRepository.UpdateAsync(appointment);
                await _unitOfWork.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while check appointment expiration.");
        }
    }

    private void SendNotification(int id,
    string title, string content, Guid userId, string nameEntity,
    NotificationLevel notificationLevel, CancellationToken cancellationToken)
    {

        var notificationMessage = new NotificationRequest
        {
            Type = NotificationType.ExpoPush,
            UserId = userId,
            Level = notificationLevel,
            Title = title,
            Content = content,
            Data = JsonSerializer.Serialize(new
            {
                Id = id,
                Entity = nameEntity
                // nameof(ScheduledService)
            })
        };
        BackgroundJob.Enqueue(() => _notifier.NotifyAsync(notificationMessage, true, cancellationToken));
    }

}