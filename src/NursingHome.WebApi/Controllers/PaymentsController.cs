using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Orders.Commands;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PaymentsController(ISender sender) : ControllerBase
{

    [HttpGet("callback/momo")]
    public async Task<IActionResult> MomoPaymentCallback(
    [FromQuery] MomoPaymentCallbackCommand callback,
    CancellationToken cancellationToken)
    {
        await sender.Send(callback, cancellationToken);
        return Redirect($"{callback.returnUrl}?isSuccess={callback.IsSuccess}");
    }

    [HttpGet("callback/vnpay")]
    public async Task<IActionResult> VnPayPaymentCallback(
        [FromQuery] VnPayPaymentCallbackCommand callback,
        CancellationToken cancellationToken)
    {
        await sender.Send(callback, cancellationToken);
        return Redirect($"{callback.returnUrl}?isSuccess={callback.IsSuccess}");
    }
}
