using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.PackageServices.Commands;
using NursingHome.Application.Features.PackageServices.Models;
using NursingHome.Application.Features.PackageServices.Queries;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PackageServiceController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get All Package Service With Pagination, Filter Name
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetPackageServiceWithPagin([FromQuery] GetAllPackageServiceQuery getAllPackageRegisterQuery, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(getAllPackageRegisterQuery, cancellationToken));
    }

    /// <summary>
    /// Get Package Service By Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<PackageServiceResponse>> GetPackageServiceByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetPackageServiceByIdQuery(id), cancellationToken);
    }

    /// <summary>
    /// OneTime thì cần trường EventDate trường SubscriberLimit , Daily thì cần trường DailyRepeat
    /// , Weekly thì cần trường DayOfWeeks và nó Có định dạng (Sunday/Monday/Tuesday/Wednesday/Thursday/Friday/Saturday)
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreatePackageService(
        [FromQuery] RepeatPatternType repeatPatternTypes,
        [FromQuery] List<int> packageType,
        CreatePackageServiceCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with
        {
            PackageServiceTypes = packageType,
            RepeatPatternTypes = repeatPatternTypes
        }, cancellationToken);
    }

    /// <summary>
    /// Update Package Service By Id
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdatePackageService(Guid id, UpdatePackageServiceCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }
}
