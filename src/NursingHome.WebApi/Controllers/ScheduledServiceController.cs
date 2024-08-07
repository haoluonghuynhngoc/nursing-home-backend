﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Features.ScheduledServices.Commands;
using NursingHome.Application.Features.ScheduledServices.Models;
using NursingHome.Application.Features.ScheduledServices.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ScheduledServiceController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<ScheduledServiceResponse>>> GetAllScheduledServiceWithPaginatedAsync(
    [FromQuery] GetAllScheduledServiceQuery request,
       CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(request, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomResponse>> GetScheduledServiceIdAsync(
       int id,
       CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(new GetScheduledServiceByIdQuery(id), cancellationToken));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> RemoveScheduledServiceAsync(int id, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(new RemoveScheduleServiceCommand(id), cancellationToken));
    }

}
