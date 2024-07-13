using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.CareServices.Models;
using NursingHome.Application.Features.CareServices.Queries;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CareServicesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CareServiceResponse>> GetCareServiceAsync(
        [FromQuery] GetCareServiceQuery request,
        CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(request, cancellationToken));
    }
}
