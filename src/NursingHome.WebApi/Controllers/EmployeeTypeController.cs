using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.EmployeeTypes.Commands;
using NursingHome.Application.Features.EmployeeTypes.Models;
using NursingHome.Application.Features.EmployeeTypes.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmployeeTypeController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<EmployeeTypeResponse>>> GetAllEmployeeTypeWithPaginAsync(
        [FromQuery] GetAllEmployeeTypeQuery query,
        CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeTypeResponse>> GetGetEmployeeTypeByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetEmployeeTypeByIdQuery(id), cancellationToken);
    }
    /// <summary>
    /// Không Cần Sài Hàm Này
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> AddMonthlyCalendarDetailCommandAsync(
        AddMonthlyCalendarDetailCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}
