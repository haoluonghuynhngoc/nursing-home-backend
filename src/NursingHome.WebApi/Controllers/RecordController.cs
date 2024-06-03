using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Records.Commands;
using NursingHome.Application.Features.Records.Models;
using NursingHome.Application.Features.Records.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecordController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllRecords([FromQuery] GetAllRecordQuery getAllRecordQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllRecordQuery, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecordResponse>> GetRecordByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetRecordByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateRecord(Guid ElderId, CreateRecordCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { ElderId = ElderId }, cancellationToken);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateRecord(Guid id, UpdateRecordCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
