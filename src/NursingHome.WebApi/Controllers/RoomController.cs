using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Features.Rooms.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RoomController(ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<RoomResponse>>> GetAllRoomsWithPaginAsync(
        [FromQuery] GetAllRoomQuery request,
        CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(request, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomResponse>> GetRoomByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(new GetRoomByIdQuery(id), cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateRoomAsync(
        CreateRoomCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPost("multi-rooms")]
    public async Task<ActionResult<MessageResponse>> CreateRoomsAutoAsync(
        CreateAutoCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateBlockAsync(
        int id,
        UpdateRoomCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
