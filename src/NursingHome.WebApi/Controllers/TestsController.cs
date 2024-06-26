﻿using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Contracts.Services.Notifications;
using NursingHome.Application.Models.Notifications;
using NursingHome.Domain.Enums;
using System.Text.Json;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TestsController(
    INotifier notifier,
    ICurrentUserService currentUserService,
    ICacheService cacheService) : ControllerBase
{
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
    //[HttpGet("cache/package/{key}")]
    //public async Task<IActionResult> GetCachePackage(string key, CancellationToken cancellationToken)
    //{
    //    return Ok(await cacheService.GetAsync<InfoStaffGennerateQrPaymentModel>(key, cancellationToken));
    //}
}
