using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Elders.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ElderController(ISender sender) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<ElderResponse>>> GetAllProfileElders(
        [FromQuery] GetElderWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ElderResponse>> GetElderById(Guid id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetElderByIdQuery(id), cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    [HttpPost("bedId")]
    public async Task<ActionResult<MessageResponse>> CreateElder(int bedId, CreateElderCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { BedId = bedId }, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateEldersById(Guid id, UpdateElderCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
