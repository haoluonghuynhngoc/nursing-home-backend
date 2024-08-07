﻿using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using System.Text.Json;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AutoController(IUnitOfWork unitOfWork,
    ILogger<AutoController> logger,
    INotifier notifier) : ControllerBase
{
    private readonly IGenericRepository<Contract> _contractRepository = unitOfWork.Repository<Contract>();
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();
    private readonly IGenericRepository<OrderDetail> _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
    private readonly IGenericRepository<ScheduledService> _scheduledServiceRepository = unitOfWork.Repository<ScheduledService>();
    private readonly IGenericRepository<Appointment> _appointmentServiceRepository = unitOfWork.Repository<Appointment>();

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
        BackgroundJob.Enqueue(() => notifier.NotifyAsync(notificationMessage, true, cancellationToken));
    }

    /// <summary>
    /// Hàm này sẽ tự chạy mỗi ngày vào lúc 12 giờ đêm mỗi ngày (Check Ngày hợp đồng cập nhật status và gửi thông báo)
    /// </summary>
    [HttpPost("check-contract-expiration")]
    public async Task<IActionResult> CheckContractExpirationAsync()
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
                await unitOfWork.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking contract expiration.");
        }
        return Ok("Check Contract Expiration Success");
    }

    /// <summary>
    /// Hàm này sẽ tự chạy mỗi ngày vào lúc 11:20 đêm mỗi ngày để đổi trạng thái của các đơn hàng (Failed ,UnPaid) Không cho thanh toán lại
    /// </summary>
    [HttpPost("check-order-expiration")]
    public async Task<IActionResult> CheckOrderExpirationAsync()
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
            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking order expiration.");
        }
        return Ok("Check Order Expiration Success");
    }

    /// <summary>
    /// Hàm này sẽ tự chạy mỗi ngày vào lúc 11:20 đêm mỗi ngày
    /// Công dụng là nó sẽ kiểm tra các đơn hàng đã thanh toán với mục đích không cho lập lại (Chạy trước hàm gợi ý)
    /// </summary>
    [HttpPost("check-order-detail-expiration")]
    public async Task<IActionResult> CheckOrderDetailExpirationAsync()
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
            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking order detail expiration.");
        }
        return Ok("Check Order Detail Expiration Success");
    }

    /// <summary>
    /// Hàm này sẽ tự chạy mỗi ngày vào lúc  11 giờ 20 phút tối ngày 24 hàng tháng
    /// gợi ý các đơn hàng lập lại cho tháng sau
    /// </summary>
    [HttpPost("create-recurring-order")]
    public async Task<IActionResult> CreateDisplayRenewalNotificationAsync()
    {
        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            var nextMonth = currentDate.AddMonths(1);

            var listOrderDetails = await _orderDetailRepository.FindAsync(
                expression: _ => _.Status == OrderDetailStatus.Repeatable
                && _.Order.Status == OrderStatus.Paid,
                includeFunc: _ => _.Include(x => x.OrderDates).Include(x => x.Order));
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

            await unitOfWork.CommitAsync();

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
        return Ok("Create Recurring Order Success");
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

    /// <summary>
    /// Hàm này sẽ tự chạy vào lúc 23h50 ngày cuối cùng của tháng
    /// đổi trạng thái của các đơn hàng lập lại thành không cho lập lại vì resert mỗi tháng
    /// </summary>
    [HttpPost("check-order-repeatable")]
    public async Task<IActionResult> CheckOrderRepeatableAsync()
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
            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while check order repeatable expiration.");
        }
        return Ok("Check Order Repeatable Success");
    }

    /// <summary>
    /// Hàm này sẽ tự chạy mỗi ngày vào lúc  11 giờ 10 phút tối mỗi ngày để kiểm tra xem lịch hẹn chưa làm gì thì tự động hủy
    /// </summary>
    [HttpPost("check-appointment-expiration")]
    public async Task<IActionResult> CheckAppointmentExpirationAsync()
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
                await unitOfWork.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while check appointment expiration.");
        }
        return Ok("Check Appointment Expiration Success");
    }
    /// <summary>
    /// xóa thông báo gia hạn hiển thị cho đơn hàng (11h59 Ngày cuối cùng của tháng)
    /// </summary>
    [HttpDelete("remove-display-renewal-notification-for-order")]
    public async Task<IActionResult> RemoveDisplayRenewalNotificationForOrderAsync()
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
            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while removing renewal notifications.");
        }
        return Ok("Remove Display Renewal Notification For Order Success");
    }
}
