using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.FamilyMembers.Commands;
public record UpdateFamilyMemberCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public GenderStatus Gender { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Relationship { get; set; }
    public string? Note { get; set; }
}
