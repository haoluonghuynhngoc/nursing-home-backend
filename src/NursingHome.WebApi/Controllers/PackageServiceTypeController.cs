using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.PackageServicesTypes.Commands;
using NursingHome.Application.Features.PackageServicesTypes.Models;
using NursingHome.Application.Features.PackageServicesTypes.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PackageServiceTypeController(ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetPackageServiceTypes([FromQuery] GetAllPackageServiceTypeQuery getAllPackageServiceTypeQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllPackageServiceTypeQuery, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PackageServiceTypeResponse>> GetPackageServiceTypesIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetByIdPackageServiceTypeQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreatePackageServiceTypes(CreatePackageServiceTypeCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdatePackageServiceTypes(int id, UpdatePackageServiceTypeCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
