using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.PackageCategories.Models;
using NursingHome.Application.Features.PackageCategories.Queries;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PackageCategoryController(ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAllPackageCategories([FromQuery] GetAllPackageCategoryQuery getAllPackageCategoryQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllPackageCategoryQuery, cancellationToken));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<PackageCategoryResponse>> GetPackageCategoryByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetPackageCategoryByIdQuery(id), cancellationToken);
    }
}
