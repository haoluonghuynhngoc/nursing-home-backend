using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.FamilyMembers.Commands;
using NursingHome.Application.Features.FamilyMembers.Models;
using NursingHome.Application.Features.FamilyMembers.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FamilyMemberController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<FamilyMemberResponse>>> GetAllFamilyMemberWithPaginAsync(
    [FromQuery] GetAllFamilyMemberQuery query,
    CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FamilyMemberResponse>> GetFamilyMemberByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetFamilyMemberByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateFamilyMemberAsync(
        CreateFamilyMemberCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateFamilyMemberAsync(
        int id,
        UpdateFamilyMemberCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteFamilyMemberAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteFamilyMemberCommand(id), cancellationToken);
    }
}
