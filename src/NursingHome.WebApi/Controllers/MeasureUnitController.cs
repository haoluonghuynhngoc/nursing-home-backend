using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.MeasureUnits.Commands;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MeasureUnitController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> CreateMeasureUnitAsync(
        int healthCategoryId,
       CreateMeasureUnitCommand command,
       CancellationToken cancellationToken)
    {
        return await sender.Send(command with { HealthCategoryId = healthCategoryId }, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateMeasureUnitAsync(
        int id,
        UpdateMeasureUnitsCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteMeasureUnitAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new RemoveMeasureUnitCommand(id), cancellationToken);
    }
}
