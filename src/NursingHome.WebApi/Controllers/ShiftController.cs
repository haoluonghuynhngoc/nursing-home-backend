using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Shifts.Commands;
using NursingHome.Application.Features.Shifts.Models;
using NursingHome.Application.Features.Shifts.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ShiftController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<ShiftResponse>>> GetAllShiftsWithPaginAsync(
   [FromQuery] GetAllShiftQuery request,
   CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(request, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShiftResponse>> GetShiftByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetShiftByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateShiftAsync(
    CreateShiftCommand command,
    CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateShiftAsync(
        int id,
        UpdateShiftCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
