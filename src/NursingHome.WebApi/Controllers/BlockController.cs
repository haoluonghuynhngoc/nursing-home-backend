using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Blocks.Commands;
using NursingHome.Application.Features.Blocks.Models;
using NursingHome.Application.Features.Blocks.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BlockController(ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetBlocksAsync(
        [FromQuery] GetAllBlocksQuery request,
        CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(request, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlockResponse>> GetBlocksByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetBlockByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateBlockAsync(
        CreateBlockCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateBlockAsync(
        int id,
        UpdateBlockCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
