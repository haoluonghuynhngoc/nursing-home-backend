using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Features.Rooms.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoomController(ISender sender) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetRooms([FromQuery] GetAllRoomCommand getAllRoomCommand, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllRoomCommand, cancellationToken));
    }

    /// <summary>
    /// 
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateRoom(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
    /// <summary>
    /// 
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateBlock(int id, UpdateRoomCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
