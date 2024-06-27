using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.ServicePackageCategories.Commands;
using NursingHome.Application.Features.ServicePackageCategories.Models;
using NursingHome.Application.Features.ServicePackageCategories.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ServicePackageCategoriesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<PackageCategoryResponse>>> GetPackageCategoryWithPaginAsync(
    [FromQuery] GetAllPackageCategoriesQuery request,
    CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PackageCategoryResponse>> GetPackageCategoryByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetPackageCategoriesByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreatePackageCategoryAsync(
    CreatePackageCategoriesCommand command,
    CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateServicePackageCategoryAsync(
        int id,
        UpdatePackageCategoriesCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
