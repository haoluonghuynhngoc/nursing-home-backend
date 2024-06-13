using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record RegisterUserSystemCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public RoleUserName? RoleRegister { get; set; }
    public string UserName { get; init; } = default!;
    public string Password { get; init; } = default!;
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string? FullName { get; init; }
    public string? AvatarUrl { get; set; }
    public string? Address { get; set; }
    public string? CCCD { get; set; }
    public GenderStatus Gender { get; set; }
    public string? DateOfBirth { get; set; }
}
