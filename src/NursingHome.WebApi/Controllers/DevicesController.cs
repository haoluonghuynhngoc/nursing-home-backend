using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Devices.Commands;
using NursingHome.Application.Features.Devices.Models;
using NursingHome.Application.Features.Devices.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DevicesController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetDevices(CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(new GetDevicesQuery(), cancellationToken));
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<DeviceResponse>> GetDeviceById(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetDeviceByIdQuery(id), cancellationToken);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateDevice(CreateDeviceCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateDevice(int id, UpdateDeviceCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteDevice(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteDeviceCommand(id), cancellationToken);
    }
    /// <summary>
    /// Only used for backend testing
    /// </summary>
    [HttpDelete]
    public async Task<ActionResult<MessageResponse>> DeleteDeviceByToken(DeleteDeviceByTokenCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

}
