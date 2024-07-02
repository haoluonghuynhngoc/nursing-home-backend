using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.OrderDates.Commands;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderDateController(ISender sender) : ControllerBase
{
    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> ChangeStatusOrderDayAsync(
            int id,
            ChangeStatusOrderDayCommand command,
            CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

}
