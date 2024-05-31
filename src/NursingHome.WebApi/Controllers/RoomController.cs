using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Rooms.Commands;
using NursingHome.Application.Features.Rooms.Queries;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoomController(ISender sender) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetRooms([FromQuery] GetAllRoomQuery getAllRoomCommand, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllRoomCommand, cancellationToken));
    }
    /// <summary>
    /// 
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomsById(int id, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(new GetRoomByIdQuery(id), cancellationToken));
    }
    /// <summary>
    /// 
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateRoom(
        Guid blockId,
        Guid packageId,
        CreateRoomCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { BlockId = blockId, PackageId = packageId }, cancellationToken);
    }

    /// <summary>
    /// Enter the room number and block id and it will automatically generate according to the information you enter
    /// </summary>
    [HttpPost("/auto")]
    public async Task<ActionResult<MessageResponse>> CreateRoomAuto(
        Guid blockId,
        Guid packageId,
        TypeEnum type,
        CreateAutoCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { BlockId = blockId, Type = type, PackageId = packageId }, cancellationToken);
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
