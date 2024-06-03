using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.PackageRegisterTypes.Commands;
using NursingHome.Application.Features.PackageRegisterTypes.Models;
using NursingHome.Application.Features.PackageRegisterTypes.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PackageRegisterTypeController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPackageRegisterTypes([FromQuery] GetAllPackageRegisterTypeQuery getAllPackageServiceTypeQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllPackageServiceTypeQuery, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PackageRegisterTypeResponse>> GetPackageRegisterTypesIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetByIdPackageRegisterTypeQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreatePackageRegisterTypes(CreatePackageRegisterTypeCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdatePackageRegisterTypes(int id, UpdatePackageRegisterTypeCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
