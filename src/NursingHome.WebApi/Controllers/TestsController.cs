using ExpoCommunityNotificationServer.Client;
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
    ICacheService cacheService,
    IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IGenericRepository<Order> _orderRepository = unitOfWork.Repository<Order>();

    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpPost("push-notification")]
    public async Task<IActionResult> Post(CancellationToken cancellationToken)
    {
        var notificationMessage = new NotificationRequest
        {
            Type = NotificationType.SystemStaffCreated,
            UserId = await currentUserService.FindCurrentUserIdAsync(),
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
        IPushApiClient _client = new PushApiClient("your token here");
        PushTicketRequest pushTicketRequest = new PushTicketRequest()
        {
            PushTo = new List<string>() { "ExponentPushToken[fxc4drPagqlftQNP2D1JSg]" },
            PushTitle = "TEST 1",
            PushBody = "TEST 1"
        };

        PushTicketResponse result = await _client.SendPushAsync(pushTicketRequest);
        return Ok(result);
    }
}
