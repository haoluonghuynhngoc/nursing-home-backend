using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.OrderDetails.Models;
using NursingHome.Application.Features.OrderDetails.Queries;
using NursingHome.Application.Features.Orders.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderDetailController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<OrderResponse>>> GetAllOrderDetailWithPaginAsync(
    [FromQuery] GetAllDateServicePackageRegister query,
    CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(query, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetailResponse>> GetOrderDetailByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetOrderDetailByIdQuery(id), cancellationToken);
    }
}
