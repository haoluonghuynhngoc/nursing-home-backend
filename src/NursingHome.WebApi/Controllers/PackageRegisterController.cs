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
    [HttpGet]
    public async Task<IActionResult> GetPackageRegisterWithPagin([FromQuery] GetAllPackageRegisterQuery getAllPackageRegisterQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllPackageRegisterQuery, cancellationToken));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<PackageRegisterResponse>> GetPackageRegisterByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetPackageRegisterByIdQuery(id), cancellationToken);
    }
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreatePackageRegister(int? packageRegisterTypeId, CreatePackageRegisterCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { PackageRegisterTypeId = packageRegisterTypeId }, cancellationToken);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdatePackageRegister(Guid id, UpdatePackageRegisterCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
    [HttpPost("room")]
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
