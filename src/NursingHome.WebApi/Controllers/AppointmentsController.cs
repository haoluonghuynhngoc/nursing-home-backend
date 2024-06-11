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
    public async Task<ActionResult<PaginatedResponse<AppointmentResponse>>> GetAppointments(
         [FromQuery] GetAppointmentsQuery query,
         CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentResponse>> GetAppointmentById(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetAppointmentByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateAppointment(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateAppointment(int id, UpdateAppointmentCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteAppointment(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteAppointmentCommand(id), cancellationToken);
    }
}
