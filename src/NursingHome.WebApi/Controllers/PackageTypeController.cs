using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.PackageTypes.Models;
using NursingHome.Application.Features.PackageTypes.Queries;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PackageTypeController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get All Package Type With Pagination, Filter Name 
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllPackageType([FromQuery] GetAllPackageTypeQuery getAllPackageTypeQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllPackageTypeQuery, cancellationToken));
    }
    /// <summary>
    /// Get Package Type By Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<PackageTypeResponse>> GetPackageTypeByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetPackageTypeByIdQuery(id), cancellationToken);
    }

}
