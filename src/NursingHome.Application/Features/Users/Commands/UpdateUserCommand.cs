using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Users.Commands;
public sealed record UpdateUserCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Address { get; set; }
    public string? CCCD { get; set; }
    public GenderStatus Gender { get; set; }
    public string? DateOfBirth { get; set; }
    public string? Email { get; init; }
}
