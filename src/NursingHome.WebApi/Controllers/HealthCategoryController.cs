using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.HealthCategories.Commands;
using NursingHome.Application.Features.HealthCategories.Models;
using NursingHome.Application.Features.HealthCategories.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HealthCategoryController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<HealthCategoryResponse>>> GetAllHealthCateroryWithPaginAsync(
        [FromQuery] GetAllHealthCategoryQuery query,
        CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HealthCategoryResponse>> GetHealthCateroryByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetHealthCategoryByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateHealthCateroryAsync(
        CreateHealthCategoryCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateHealthCateroryAsync(
        int id,
        UpdateHealthCategoryCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
    [HttpPut("{id}/change-state")]
    public async Task<ActionResult<MessageResponse>> ChangeStateHealthCateroryAsync(
    int id, UpdateStateHealthCategoryCommand command,
    CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteHealthCateroryAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteHealthCategoryCommand(id), cancellationToken);
    }
}
