using MediatR;

namespace NursingHome.Application.Features.Users.Commands;
using NursingHome.Application.Models;
public sealed record UpdateProfileCommand : IRequest<MessageResponse>
{
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
}
