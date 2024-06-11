using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record RegisterCutomerCommand : IRequest<MessageResponse>
{
    public string PhoneNumber { get; set; } = default!;
    public string? Password { get; set; }
    public string? FullName { get; set; }
    public string? CCCD { get; set; }
    public string? Address { get; set; }
    public string? Email { get; init; }
}
