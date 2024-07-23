using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.CareSchedules.Commands;
using NursingHome.Application.Features.CareSchedules.Models;
using NursingHome.Application.Features.CareSchedules.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CareScheduleController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<CareScheduleResponse>>> GetAllCareSchedulesAllBlocksWithAsync(
       [FromQuery] GetAllCareScheduleQuery request,
       CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(request, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CareScheduleResponse>> GetCareScheduleByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetCareScheduleByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateCareScheduleAsync(
        CreateCareScheduleCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    //[HttpPut("{id}")]
    //public async Task<ActionResult<MessageResponse>> UpdateContractAsync(
    //    int id,
    //    UpdateContractCommand command, CancellationToken cancellationToken)
    //{
    //    return await sender.Send(command with { Id = id }, cancellationToken);
    //}

    //[HttpDelete("{id}")]
    //public async Task<ActionResult<MessageResponse>> UpdateContractAsync(
    //    int id,
    //    RemoveContractCommand command,
    //    CancellationToken cancellationToken)
    //{
    //    return await sender.Send(command with { Id = id }, cancellationToken);
    //}
}
