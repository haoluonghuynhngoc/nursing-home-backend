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

    [HttpPut("{id}")]
    public async Task<ActionResult<MessageResponse>> UpdateShiftAsync(
           Guid id,
           UpdateUserCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { Id = id }, cancellationToken);
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
    /// Đăng ký được tất cả các loai tài khoản như : Admin, Manager, Staff  nếu để RoleUserName là Customer thì hệ thống sẽ
    /// mặt định là role Nurse
    /// </summary>
    [HttpPost("system-register")]
    public async Task<ActionResult<MessageResponse>> RegisterSystemProfile(RoleUserName roleRegister, RegisterUserSystemCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command with { RoleRegister = roleRegister }, cancellationToken);
    }
    /// <summary>
    /// chỉ đăng ký tài khoản customer, mặt định password là 1 sau này đổi lại thành password random và send sms cho khách hàng
    /// </summary>
    [HttpPost("customer-register")]
    [AllowAnonymous]
    public async Task<ActionResult<MessageResponse>> RegisterUserProfile(RegisterCutomerCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
    /// <summary>
    /// Hàm này dựa vào token đang đăng nhập để sử dụng khi mà tài khoảng đó chưa có password, nếu có password thì sẽ không thể thay đổi password
    /// </summary>
    [HttpPatch("set-password")]
    public async Task<ActionResult<MessageResponse>> SetPassword(SetPasswordCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Hàm này sẽ lấy token đang đăng nhập và nhập password cũ để thay đổi password mới
    /// </summary>
    [HttpPost("change-password")]
    public async Task<ActionResult<MessageResponse>> ChangePassword(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }

    /// <summary>
    /// Hàm này sẽ dựa vào token đang đăng nhập để thay đổi password cho tài khoản đó mà không cần biết password cũ
    /// </summary>
    [HttpPost("reset-password")]
    public async Task<ActionResult<MessageResponse>> ResetPassword(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        return await sender.Send(request, cancellationToken);
    }

}
