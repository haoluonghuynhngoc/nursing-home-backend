using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.EmployeeSchedules.Models;
using NursingHome.Application.Features.EmployeeSchedules.Queries;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmployeeScheduleController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<EmployeeSchedulesResponse>>> GetAllEmployeeScheduleWithPaginAsync(
    [FromQuery] GetAllEmployeeScheduleQuery query,
    CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
}
