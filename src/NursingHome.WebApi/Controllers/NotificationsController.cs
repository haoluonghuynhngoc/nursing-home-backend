using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Notifications.Commands;
using NursingHome.Application.Features.Notifications.Models;
using NursingHome.Application.Features.Notifications.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NotificationsController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<NotificationPaginatedResponse>> GetNotifications(
        [FromQuery] GetNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<NotificationResponse>> GetNotificationById(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetNotificationByIdQuery(id), cancellationToken);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpPatch("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateNotificationStatus(
        int id,
        UpdateNotificationStatusCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpPatch("readAll")]
    public async Task<ActionResult<MessageResponse>> ReadAllNotification(
        CancellationToken cancellationToken)
    {
        return await sender.Send(new ReadAllNotificationCommand(), cancellationToken);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteNotification(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteNotificationCommand(id), cancellationToken);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpDelete]
    public async Task<ActionResult<MessageResponse>> DeleteListNotification(
        DeleteListNotificationCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

}
