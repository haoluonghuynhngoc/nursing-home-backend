using MediatR;

namespace NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
public sealed record SetPasswordCommand : IRequest<MessageResponse>
{
    public string? FullName { get; set; }
    public string NewPassword { get; set; } = default!;
}
