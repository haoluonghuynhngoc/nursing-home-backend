﻿using ExpoCommunityNotificationServer.Client;
using ExpoCommunityNotificationServer.Models;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using System.Text.Json;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TestsController(
    INotifier notifier,
    ICurrentUserService currentUserService,
    IEmailSender emailSender,
    ICacheService cacheService,
    IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();

    [HttpPost("test-send-mail")]
    public async Task<IActionResult> TestsMailController()
    {
        var emailSubject = "Đo chỉ số sức khỏe ngày ";

        var emailBody = @"<!DOCTYPE html>
        <html lang='vi'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Báo Cáo Sức Khỏe</title>
        </head>
        <body>
            <div style='font-family: Arial, sans-serif;'>
                <h2>Báo Cáo Sức Khỏe</h2>
                <p>Xin chào [Tên Bệnh Nhân],</p>
                <p>Chúng tôi xin gửi đến bạn báo cáo sức khỏe sau khi khám định kỳ ngày [Ngày Khám]:</p>
                <h3>Kết Quả Khám Sức Khỏe</h3>
                <ul>
                    <li>Chiều cao: [Chiều Cao] cm</li>
                    <li>Cân nặng: [Cân Nặng] kg</li>
                    <li>Huyết áp: [Huyết Áp]</li>
                    <li>Nhịp tim: [Nhịp Tim] lần/phút</li>
                    <li>Cholesterol: [Cholesterol] mg/dL</li>
                    <li>Đường huyết: [Đường Huyết] mg/dL</li>
                </ul>
                <h3>Đánh Giá Chung</h3>
                <p>[Đánh Giá Chung]</p>
                <h3>Khuyến Nghị</h3>
                <p>[Khuyến Nghị]</p>
                <p>Xin cảm ơn bạn đã tin tưởng và sử dụng dịch vụ của chúng tôi.</p>
                 <img src='https://support.content.office.net/en-us/media/7dbd87dd-c244-4d78-8fda-4408a08582cc.jpg' alt='Congratulations Image' style='max-width: 100%;'>
            </div>
        </body>
        </html";

        await emailSender.SendEmailAsync("haolhnse150758@fpt.edu.vn", emailSubject, emailBody);
        return Ok("Test send mail");
    }

    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpPost("push-notification")]
    public async Task<IActionResult> Post(CancellationToken cancellationToken)
    {
        var notificationMessage = new NotificationRequest
        {
            Type = NotificationType.ExpoPush,
            UserId = await currentUserService.FindCurrentUserIdAsync(),
            Level = NotificationLevel.Information,
            Title = "Test Notification",
            Content = "This is a test notification",
            Data = JsonSerializer.Serialize(new
            {
                Id = Guid.NewGuid(),
                Entity = nameof(User)
            })
        };

        BackgroundJob.Enqueue(() => notifier.NotifyAsync(notificationMessage, true, cancellationToken));

        return Ok("push success");
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpPost("cache/{key}")]
    //[AllowAnonymous]
    public async Task<IActionResult> PostCahce(string key, string value, CancellationToken cancellationToken)
    {
        await cacheService.SetAsync(key, value, cancellationToken);
        return Ok(key);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpGet("cache/{key}")]
    //[AllowAnonymous]
    public async Task<IActionResult> GetCache(string key, CancellationToken cancellationToken)
    {
        return Ok(await cacheService.GetAsync<string>(key, cancellationToken));
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpDelete("cache/{key}")]
    //[AllowAnonymous]
    public async Task<IActionResult> DeleteCache(string key, CancellationToken cancellationToken)
    {
        await cacheService.RemoveAsync(key, cancellationToken);
        return Ok("Okey");
    }
    // nữa sẽ xóa 
    [HttpPost("checkOrderExpiration")]
    public async Task<IActionResult> CheckOrderExpirationApiAsync()
    {
        try
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            // check cai nay 
            var listOrders = await _orderRepository.FindAsync(
                expression: _ => _.Status == OrderStatus.UnPaid
                || _.Status == OrderStatus.Failed, includeFunc: _ => _.Include(x => x.OrderDetails)
                .ThenInclude(x => x.OrderDates)
                .AsNoTracking()); // Thêm AsNoTracking để tăng hiệu suất nếu không cần theo dõi các thay đổi

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
            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
        }
        return Ok("Check Order Succesfully");
    }
    //[HttpGet("cache/package/{key}")]
    //public async Task<IActionResult> GetCachePackage(string key, CancellationToken cancellationToken)
    //{
    //    return Ok(await cacheService.GetAsync<InfoStaffGennerateQrPaymentModel>(key, cancellationToken));
    //}

    [HttpPost("exxpo")]
    public async Task<IActionResult> PostCahcePackage()
    {
        //IPushApiClient _client = new PushApiClient("ehAXa94NsN6NnpSTLLZkb2vnmxZC3Y-vF0k7xDkk");
        IPushApiClient _client = new PushApiClient("ehAXa94NsN6NnpSTLLZkb2vnmxZC3Y-vF0k7xDkk");
        PushTicketRequest pushTicketRequest = new PushTicketRequest()
        {
            // ExponentPushToken[2TCZk1JFMD5CJA_WfvoUWS]   || "ExponentPushToken[fxc4drPagqlftQNP2D1JSg]", "ExponentPushToken[LYbkmXI2vH3-PvFNIzVRTW]" 
            PushTo = new List<string>() { "ExponentPushToken[u_mFsLH_ECaVA9WbxeW8FZ]" },
            PushTitle = "Api Mơi Tạo ",
            PushBody = "TEST 11111"
        };

        PushTicketResponse result = await _client.SendPushAsync(pushTicketRequest);
        return Ok(result);
    }
}
