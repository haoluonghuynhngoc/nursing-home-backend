using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record RegisterRequest : IRequest<MessageResponse>
{
    public string? UserName { get; set; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string? FullName { get; init; }
    public string? RoleName { get; init; }
    // public RoleName roleName { get; set; }
    public string Password { get; init; } = default!;

}
