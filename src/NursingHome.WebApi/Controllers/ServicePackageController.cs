using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.ServicePackages.Commands;
using NursingHome.Application.Features.ServicePackages.Models;
using NursingHome.Application.Features.ServicePackages.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ServicePackageController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<ServicePackageResponse>>> GetPackagesAsync(
         [FromQuery] GetAllServicePackageQuery query,
         CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServicePackageResponse>> GetPackageByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetServicePackageByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreatePackageAsync(CreateServicePackageCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdatePackageAsync(int id, UpdateServicePackageCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpPut("{id}/change-state")]
    public async Task<ActionResult<MessageResponse>> ChangeStatePackageAsync(
        int id, ChangeStateServicePackageCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeletePackageAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteServicepackageCommand(id), cancellationToken);
    }
}
