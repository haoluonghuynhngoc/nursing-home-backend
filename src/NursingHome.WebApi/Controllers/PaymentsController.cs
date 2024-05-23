using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Payments.Commands;

namespace NursingHome.WebApi.Controllers;
[Route("api/[Controller]")]
[ApiController]
public class PaymentsController(ISender sender, IHttpContextAccessor httpContextAccessor) : ControllerBase
{
    [HttpGet("momo-callback")]
    public async Task<IActionResult> MomoPaymentCallback(
    [FromQuery] MomoPaymentCallbackCommand callback,
    CancellationToken cancellationToken)
    {
        await sender.Send(callback, cancellationToken);
        return Redirect($"{callback.returnUrl}?isSuccess={callback.IsSuccess}");
    }
    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit(
    DepositCommand command,
    string returnUrl,
    CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(command with { returnUrl = returnUrl }, cancellationToken));
    }
    [HttpGet("{id}")]
    public IActionResult GetPayment(int id, [FromQuery] bool isSuccess)
    {
        // Xử lý logic cho phương thức này
        // id sẽ là 1111 và isSuccess sẽ là True từ URL /api/payments/1111?isSuccess=True

        // Ví dụ trả về response với id và isSuccess nhận được
        return Ok(new { PaymentId = id, IsSuccess = isSuccess });
    }

}
