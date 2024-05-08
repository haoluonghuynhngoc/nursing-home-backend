using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record ChangePasswordRequest : IRequest<MessageResponse>
{
    public string OldPassword { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
}
