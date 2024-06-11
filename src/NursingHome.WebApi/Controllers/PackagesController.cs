using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.PackageFeature.Commands;
using NursingHome.Application.Features.PackageFeature.Models;
using NursingHome.Application.Features.PackageFeature.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PackagesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<PackageResponse>>> GetPackages(
         [FromQuery] GetPackagesQuery query,
         CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PackageResponse>> GetPackageById(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetPackageByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreatePackage(CreatePackageCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdatePackage(int id, UpdatePackageCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeletePackage(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeletePackageCommand(id), cancellationToken);
    }
}
