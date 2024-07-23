using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.NursingPackages.Commands;
using NursingHome.Application.Features.NursingPackages.Models;
using NursingHome.Application.Features.NursingPackages.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NursingPackageController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<NursingPackageResponse>>> GetNursingPackagesAsync(
        [FromQuery] GetAllNursingPackageQuery query,
        CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NursingPackageResponse>> GetNursingPackageByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetNursingPackageByIdQuery(id), cancellationToken);
    }

    [HttpPost("AddNursingPackageToRoom")]
    public async Task<ActionResult<MessageResponse>> AddNursingPackageToRoomAsync(AddNursingPackageToRoomCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateNursingPackageAsync(CreateNursingPackageCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateNursingPackageAsync(int id, UpdateNursingPackageCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
    [HttpPut("{id}/change-state")]
    public async Task<ActionResult<MessageResponse>> ChangeStateNursingPackageAsync(
        int id, ChangeStateNursingPackageCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
    //[HttpDelete("{id}")]
    //public async Task<ActionResult<MessageResponse>> DeleteNursingPackage(int id, CancellationToken cancellationToken)
    //{
    //    return await sender.Send(new DeleteNursingPackageCommand(id), cancellationToken);
    //}
}
