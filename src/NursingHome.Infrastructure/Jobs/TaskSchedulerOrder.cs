using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Jobs;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
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
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<Elder> _elderRepository;
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository;
    private readonly IEmailSender _emailSender;
    private readonly INotifier _notifier;
    public TaskSchedulerOrder(IUnitOfWork unitOfWork, IEmailSender emailSender, INotifier INotifier, ILogger<TaskSchedulerOrder> logger)
    {
        _notifier = INotifier;
        _emailSender = emailSender;
        _unitOfWork = unitOfWork;
        _contractRepository = unitOfWork.Repository<Contract>();
        _orderRepository = unitOfWork.Repository<Order>();
        _orderDetailRepository = unitOfWork.Repository<OrderDetail>();
        _scheduledServiceRepository = unitOfWork.Repository<ScheduledService>();
        _appointmentServiceRepository = unitOfWork.Repository<Appointment>();
        _elderRepository = unitOfWork.Repository<Elder>();
        _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();
        _orderDateRepository = unitOfWork.Repository<OrderDate>();
        _userRepository = unitOfWork.Repository<User>();
        this.logger = logger;
    }
    public async Task CheckContractExpirationAsync()
    {
        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            var listContracts = await _contractRepository.FindAsync(
                expression: _ => _.Status != ContractStatus.Expired && _.Status != ContractStatus.Cancelled);
            // hơi lỏ khi gửi mail như cũng sài được do là api động
            foreach (var contract in listContracts)
            {
                if (contract.NursingPackageId != null)
                {
                    var elder = await _elderRepository.FindByIdAsync(contract.ElderId);
                    var user = await _userRepository.FindByIdAsync(contract.UserId);
                    var nursingPackage = await _nursingPackageRepository.FindByIdAsync(contract.NursingPackageId);
                    if (elder != null && user != null && nursingPackage != null)
                    {
                        if (contract.StartDate == currentDate)
                        {
                            contract.Status = ContractStatus.Valid;
                            SendNotification(contract.Id, $"Thông Báo Hợp Đồng Ngày {currentDate:dd/MM/yyyy}",
                               $"Hợp đồng có hiệu lực: Hợp đồng có mã {contract.Name} có hiệu lực vào ngày {currentDate:dd/MM/yyyy}.",
                             contract.UserId, nameof(Contract), NotificationLevel.Information, CancellationToken.None);
                            await SendMail(contract, elder, nursingPackage, user, contract.StartDate, "#4CAF50", "Hợp Đồng Đã Có Hiệu Lực");
                        }

                        var notificationDate = contract.EndDate;
                        if (notificationDate.AddDays(-30) == currentDate)
                        {
                            SendNotification(contract.Id, $"Thông Báo Hợp Đồng Ngày {currentDate:dd/MM/yyyy}",
                              $"Hợp đồng sắp hết hạn (cách 30 ngày): Bạn có muốn gia hạn hợp đồng có mã {contract.Name} sẽ hết hạn vào ngày {contract.EndDate:dd/MM/yyyy}",
                            contract.UserId, nameof(Contract), NotificationLevel.Information, CancellationToken.None);
                            await SendMail(contract, elder, nursingPackage, user, contract.StartDate, "#FF9800", "Hợp Đồng Sắp Hết Hạn");
                        }
                        if (contract.EndDate <= currentDate)
                        {
                            contract.Status = ContractStatus.Expired;
                            SendNotification(contract.Id, $"Thông Báo Hợp Đồng Ngày {currentDate:dd/MM/yyyy}",
                             $"Hợp đồng có mã {contract.Name} đã hết hạn vào ngày{currentDate:dd/MM/yyyy}.",
                           contract.UserId, nameof(Contract), NotificationLevel.Information, CancellationToken.None);
                            await SendMail(contract, elder, nursingPackage, user, contract.StartDate, "#F44336", "Hợp Đồng Đã Hết Hạn");
                        }
                        await _contractRepository.UpdateAsync(contract);
                        await _unitOfWork.CommitAsync();
                    }

                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking contract expiration.");
        }
    }
    private async Task SendMail(Contract contract, Elder elder, NursingPackage nursingPackage, User user, DateOnly date, string color, string title)
    {
        try
        {
            var content = contract.Status switch
            {
                ContractStatus.Valid => "Hợp đồng đã có hiệu lực",
                ContractStatus.Pending => "Hợp đồng đang chờ xác nhận",
                ContractStatus.Expired => "Hợp đồng đã hết hạn",
                ContractStatus.Cancelled => "Hợp đồng đã bị hủy",
                _ => "Hợp đồng không xác định"
            };

            var emailSubject = $"Thông báo về tình trạng hợp đồng ngày {date:dd/MM/yyyy}";
            var emailBody = $@"<!DOCTYPE html>
           <html lang='vi'>
           <head>
               <meta charset='UTF-8'>
               <meta name='viewport' content='width=device-width, initial-scale=1.0'>
               <title>Thông Báo Tình Trạng Hợp Đồng: {contract.Name}</title>
               <style>
                   body {{
                       font-family: Arial, sans-serif;
                       line-height: 1.6;
                       color: #333;
                       background-color: #f4f4f4;
                       margin: 0;
                       padding: 0;
                   }}
                   .container {{
                       width: 100%;
                       max-width: 600px;
                       margin: 30px auto;
                       padding: 20px;
                       border: 1px solid #ddd;
                       border-radius: 10px;
                       background-color: #fff;
                       box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                   }}
                   h2 {{
                       color: {color};
                       font-size: 28px;
                       text-align: center; 
                       margin-bottom: 20px;
                   }}
                   p {{
                       font-size: 16px;
                       margin-bottom: 10px;
                   }}
                   ul {{
                       list-style-type: none;
                       padding: 0;
                       margin: 0;
                   }}
                   ul li {{
                       padding: 10px;
                       margin-bottom: 10px;
                       background: #f9f9f9;
                       border-left: 4px solid {color};
                       border-radius: 5px;
                       font-size: 15px;
                   }}
                   ul li strong {{
                       display: inline-block;
                       width: 150px;
                       font-weight: bold;
                   }}
                   .footer {{
                       margin-top: 30px;
                       text-align: center;
                       font-size: 14px;
                       color: #888;
                   }}
                   .footer img {{
                       margin-top: 20px;
                       max-width: 100%;
                       border-radius: 10px;
                       box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
                   }}
               </style>
           </head>
           <body>
               <div class='container'>
                   <h2>{title}</h2>
                   <p>Kính gửi {user.FullName},</p>
                   <p>Chúng tôi xin thông báo tình trạng hợp đồng của bạn như sau:</p>
        
                   <h3>Chi Tiết Hợp Đồng</h3>
                   <ul>
                       <li><strong>Tên Hợp Đồng:</strong> {contract.Name}</li>
                       <li><strong>Tên Người Cao Tuổi:</strong> {elder.Name}</li>
                       <li><strong>Tên Người Giám Hộ:</strong> {user.FullName}</li>
                       <li><strong>Gói Dưỡng Lão:</strong> {nursingPackage.Name}</li>
                       <li><strong>Trạng Thái:</strong> {content}</li>
                       <li><strong>Ngày Ký:</strong> {contract.SigningDate:dd-MM-yyyy}</li>
                       <li><strong>Ngày Có Hiệu Lực:</strong> {contract.StartDate:dd-MM-yyyy}</li>
                       <li><strong>Ngày Hết Hạn:</strong> {contract.EndDate:dd-MM-yyyy}</li>
                       <li><strong>Ghi Chú:</strong> {contract.Notes}</li>
                   </ul>

                   <h3>Trạng Thái Hợp Đồng</h3>
                   <p>{content}</p>

                   <div class='footer'>
                       <p>Xin cảm ơn bạn đã tin tưởng và sử dụng dịch vụ của chúng tôi.</p>
                       <img src='https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ff4dbf5a6-1495-4314-9e64-52e35d2564fd.png?alt=media&token=926dd20b-667a-431d-a1a7-dc7fec3243e5' alt='Contract Status Image'>
                   </div>
               </div>
           </body>
           </html>";

            if (user.Email != null)
            {
                await _emailSender.SendEmailAsync(user.Email, emailSubject, emailBody);
            }
        }
        catch (Exception ex)
        {
            // Xử lý ngoại lệ tại đây, ví dụ: ghi log hoặc thông báo lỗi
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