using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.DiseaseCategories.Commands;
using NursingHome.Application.Features.DiseaseCategories.Models;
using NursingHome.Application.Features.DiseaseCategories.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DiseaseCategoryController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<DiseaseCategoryResponse>>> GetAllDiseaseCategoryWithPaginAsync(
        [FromQuery] GetAllDiseaseCategoryQuery request,
        CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DiseaseCategoryResponse>> GetDiseaseCategoryByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetDiseaseCategoryByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateDiseaseCategoryAsync(
        CreateDiseaseCategoryCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateDiseaseCategoryAsync(
        int id,
        UpdateDiseaseCategoryCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
