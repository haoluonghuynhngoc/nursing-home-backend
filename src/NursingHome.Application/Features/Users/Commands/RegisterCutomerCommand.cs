using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record RegisterCutomerCommand : IRequest<MessageResponse>
{
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Address { get; set; }
    public string? CCCD { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public GenderStatus Gender { get; set; }
    public string? DateOfBirth { get; set; }
    public string? Password { get; set; }
    public string? Email { get; init; }
}
