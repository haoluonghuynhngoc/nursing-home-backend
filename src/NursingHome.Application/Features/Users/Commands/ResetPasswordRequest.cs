using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record ResetPasswordRequest : IRequest<MessageResponse>
{
    public string NewPassword { get; init; } = default!;
}

