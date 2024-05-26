using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.HealthReportCategories.Commands;
using NursingHome.Application.Features.HealthReportCategories.Models;
using NursingHome.Application.Features.HealthReportCategories.Queries;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HealthCateroryController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get All Health Caterory With Pagination, Filter Name
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetHealthCategory([FromQuery] GetAllCategoryQuery getAllCategoryQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllCategoryQuery, cancellationToken));
    }

    /// <summary>
    /// Get Health Caterory By Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ReportCategoryResponse>> GetHealthCategoryByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetCategoryByIdQuery(id), cancellationToken);
    }

    /// <summary>
    /// Create Health Caterory
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateHealthCategory(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Update Health Category By Id
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateHealthCategory(int id, UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
