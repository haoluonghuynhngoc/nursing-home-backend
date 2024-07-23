using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.PotentialCustomers.Commands;
using NursingHome.Application.Features.PotentialCustomers.Models;
using NursingHome.Application.Features.PotentialCustomers.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PotentialCustomerController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<PotentialCustomerResponse>>> GetAllPotentialCustomerWithPaginatedAsync(
    [FromQuery] GetAllPotentialCustomerQuery request,
    CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(request, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PotentialCustomerResponse>> GetPotentialCustomerByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetPotentialCustomerByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreatePotentialCustomerAsync(
        CreatePotentialCustomerCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdatePotentialCustomerAsync(
        int id,
        UpdatePotentialCustomerCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpPut("{id}/change-state")]
    public async Task<ActionResult<MessageResponse>> ChangeStatePotentialCustomerAsync(
        int id, ChangeStatePotentialCustomerCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdatePotentialCustomerAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new DeletePotentialCustomerCommand(id), cancellationToken);
    }
}
