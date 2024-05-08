using MediatR;

namespace NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;

public sealed record ResetPasswordRequest : IRequest<MessageResponse>
{
    public string NewPassword { get; init; } = default!;
}
