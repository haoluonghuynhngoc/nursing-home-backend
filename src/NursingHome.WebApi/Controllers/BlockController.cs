using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Blocks.Commands;
using NursingHome.Application.Features.Blocks.Models;
using NursingHome.Application.Features.Blocks.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlockController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get All Blocks With Pagination, Filter Name And Total Floor, Sort By Name
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetBlocks([FromQuery] GetAllBlocksQuery getAllProfileUserQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllProfileUserQuery, cancellationToken));
    }
    /// <summary>
    /// Get Block By Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<BlockResponse>> GetBlocksByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetBlockByIdQuery(id), cancellationToken);
    }
    /// <summary>
    /// Create Block
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateBlock(CreateBlockCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
    /// <summary>
    /// Update Block By Id
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateBlock(Guid id, UpdateBlockCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
