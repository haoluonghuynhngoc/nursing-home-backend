using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.HealthReports.Commands;
using NursingHome.Application.Features.HealthReports.Models;
using NursingHome.Application.Features.HealthReports.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HealthReportController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<HealthReportResponse>>> GetAllHealthReportWithPaginAsync(
   [FromQuery] GetAllHealthReportQuery query,
   CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HealthReportResponse>> GetHealthReportByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetHealthReportByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateHealthReportAsync(
        CreateHealthReportCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    //[HttpPut("{id}")]
    //public async Task<ActionResult<MessageResponse>> UpdateHealthReportAsync(
    //    int id,
    //    UpdateHealthCategoryCommand command,
    //    CancellationToken cancellationToken)
    //{
    //    return await sender.Send(command with { Id = id }, cancellationToken);
    //}

    //[HttpDelete("{id}")]
    //public async Task<ActionResult<MessageResponse>> DeleteHealthReportAsync(int id, CancellationToken cancellationToken)
    //{
    //    return await sender.Send(new DeleteHealthCategoryCommand(id), cancellationToken);
    //}
}
