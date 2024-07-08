using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Appointments.Commands;
using NursingHome.Application.Features.Appointments.Models;
using NursingHome.Application.Features.Appointments.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AppointmentsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<AppointmentResponse>>> GetAllAppointmentsWithPaginAsync(
         [FromQuery] GetAppointmentsQuery query,
         CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentResponse>> GetAppointmentByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetAppointmentByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateAppointmentAsync(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateAppointmentAsync(int id, UpdateAppointmentCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpPut("ChangeStatus/{id}")]
    public async Task<ActionResult<MessageResponse>> ChangeStatusAppointmentAsync(int id, ChangeStatusAppointmentCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteAppointmentAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteAppointmentCommand(id), cancellationToken);
    }
}
