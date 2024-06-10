using MediatR;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Auth.Commands;
using NursingHome.Application.Features.Auth.Models;
using NursingHome.Application.Models;

namespace NursingHome.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Login for admin, staff , director, manager, nurses, user
    /// </summary>
    /// <remarks>
    /// ```
    /// Admin account: admin - admin
    /// Staff account: staff - staff
    /// Director account: director - director
    /// Manager account: manager - manager
    /// Nurses account: nurses - nurses
    /// User account: user - user
    /// ```
    /// </remarks>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult<AccessTokenResponse>> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }

    /// <summary>
    /// cannot be used yet
    /// </summary>
    /// <param name="request">
    /// ```
    /// The beginning of the phone number can be (0 or +84 or 84)
    /// 
    /// Regex phone number: ^(\+84|84|0)[35789][0-9]{8}$
    /// ```
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("send-otp")]
    public async Task<ActionResult<MessageResponse>> SendOtp(SendOtpRequest request, CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }
    /// <summary>
    /// cannot be used yet
    /// </summary>
    [HttpPost("verify-otp")]
    public async Task<ActionResult<AccessTokenResponse>> VerifyOtp(VerifyOtpRequest request, CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }
    /// <summary>
    /// cannot be used yet
    /// </summary>
    [HttpPost("refresh")]
    public async Task<ActionResult<AccessTokenResponse>> RefreshToken(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }
}
