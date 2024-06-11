using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Roles.Models;
using NursingHome.Application.Features.Roles.Queries;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RolesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(new GetRolesQuery(), cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleResponse>> GetRoleById(Guid id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetRoleByIdQuery(id), cancellationToken);
    }
}