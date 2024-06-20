using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Orders.Commands;
using NursingHome.Application.Features.Orders.Models;
using NursingHome.Application.Features.Orders.Queries;
using NursingHome.Application.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrdersController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<OrderResponse>>> GetAllOrdersWithPaginAsync(
    [FromQuery] GetOrdersQuery query,
    CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponse>> GetOrderByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await sender.Send(new GetOrderByIdQuery(id), cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateOrderAsync(
        int id,
        UpdateOrderCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
    }

    [HttpPost("service-package")]
    public async Task<ActionResult<MessageResponse>> CreateOrderServicePackage(
        string returnUrl,
        CreateOrderServicePackageCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command with { returnUrl = returnUrl }, cancellationToken);
    }

    [HttpPost("nursing-package")]
    public async Task<ActionResult<MessageResponse>> CreateOrderNursingPackage(
        CreateOrderNursingPackageCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MessageResponse>> DeleteOrderAsync(int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new DeleteOrderCommand(id), cancellationToken);
    }
}
