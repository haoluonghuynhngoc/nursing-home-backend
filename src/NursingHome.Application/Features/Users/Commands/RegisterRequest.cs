using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record RegisterRequest : IRequest<MessageResponse>
{
    public string? UserName { get; set; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string? FullName { get; init; }
    [JsonIgnore]
    public RoleRegister? RoleRegister { get; set; }
    // public RoleName roleName { get; set; }
    public string Password { get; init; } = default!;

}
