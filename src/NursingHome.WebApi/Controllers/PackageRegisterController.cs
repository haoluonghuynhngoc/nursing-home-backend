using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.PackageRegister.Commands;
using NursingHome.Application.Features.PackageRegister.Models;
using NursingHome.Application.Features.PackageRegister.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PackageRegisterController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get All Package Register With Pagination, Filter Name
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetPackageRegisterWithPagin([FromQuery] GetAllPackageRegisterQuery getAllPackageRegisterQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllPackageRegisterQuery, cancellationToken));
    }

    /// <summary>
    /// Get Package Register By Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<PackageRegisterResponse>> GetPackageRegisterByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetPackageRegisterByIdQuery(id), cancellationToken);
    }

    /// <summary>
    /// Create Package Register
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreatePackageRegister(CreatePackageRegisterCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Update Package Register By Id
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdatePackageRegister(Guid id, UpdatePackageRegisterCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
    /// <summary>
    /// 
    /// </summary>
    [HttpPut]
    public async Task<ActionResult<MessageResponse>> AddPackageToRoom(
        [FromQuery] List<int> rooms,
        [FromQuery] Guid package,
        [FromBody] AddPackageRegisterRoomCommand command,
        CancellationToken cancellationToken)
    {
        if (rooms == null || !rooms.Any())
        {
            return BadRequest("Room list cannot be empty.");
        }
        if (package == Guid.Empty)
        {
            return BadRequest("Package ID is required.");
        }
        command.Rooms = rooms;
        command.PackageRegisterId = package;
        var response = await sender.Send(command, cancellationToken);
        return Ok(response);
    }

}
