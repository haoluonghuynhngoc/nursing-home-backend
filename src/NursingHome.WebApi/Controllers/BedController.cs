using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Beds.Commands;
using NursingHome.Application.Features.Beds.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BedController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get All Bed With Pagination, Filter Status
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetBeds([FromQuery] GetAllBedQuery getAllBedQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllBedQuery, cancellationToken));
    }
    /// <summary>
    /// Do not delete, mainly remove that bed from the room and the elderly
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteBedsByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new RemoveBedCommand(id), cancellationToken);
    }
    /// <summary>
    /// Create Bed
    /// </summary>
    [HttpPost("roomId")]
    public async Task<ActionResult<MessageResponse>> CreateBed(int roomId, CreateBedCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { RoomId = roomId }, cancellationToken);
    }
    /// <summary>
    /// Update Block By Id
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateBed(int id, UpdateBedCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
