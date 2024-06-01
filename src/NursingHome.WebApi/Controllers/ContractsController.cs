using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Contracts.Commands;
using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Features.Contracts.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContractsController(ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetContracts([FromQuery] GetAllContractQuery getAllProfileUserQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllProfileUserQuery, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContractResponse>> GetContractsByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetContractByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateContract(Guid elderId, Guid customerId, CreateContractCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { ElderId = elderId, UserId = customerId }, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateContract(Guid id, UpdateContractCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateContract(Guid id, RemoveContractCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
