using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Features.Users.Models;
using NursingHome.Application.Features.Users.Queries;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;

namespace NursingHome.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get the exact account currently logged in
    /// </summary>
    [HttpGet("profile")]
    public async Task<ActionResult<UserResponse>> GetProfile(CancellationToken cancellationToken)
    {
        return await sender.Send(new GetProfileQuery(), cancellationToken);
    }
    /// <summary>
    /// Get the account user by Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GettUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetUserByIdQuery(id), cancellationToken);
    }
    /// <summary>
    /// Get all profile users
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<UserResponse>>> GetAllProfileUsers(
        [FromQuery] GetAllProfileUserQuery request,
        CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }
    /// <summary>
    /// Update the currently logged in user
    /// </summary>
    [HttpPut("profile")]
    public async Task<ActionResult<MessageResponse>> UpdateProfile(UpdateProfileCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
    /// <summary>
    /// requires fields such as userName, roleName, password (nurse, staff, manager, director) ||
    /// requires fields phoneNumber, password to register (customer)
    /// </summary>
    [HttpPost("register")]
    public async Task<ActionResult<MessageResponse>> RegisterProfile(RoleRegister roleRegister, RegisterRequest command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { RoleRegister = roleRegister }, cancellationToken);
    }
    [HttpPatch("set-password")]
    public async Task<ActionResult<MessageResponse>> SetPassword(SetPasswordCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    [HttpPost("change-password")]
    public async Task<ActionResult<MessageResponse>> ChangePassword(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }

    [HttpPost("reset-password")]
    public async Task<ActionResult<MessageResponse>> ResetPassword(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }

}
