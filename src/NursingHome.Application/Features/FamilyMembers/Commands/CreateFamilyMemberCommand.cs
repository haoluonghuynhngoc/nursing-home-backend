using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.FamilyMembers.Commands;
public sealed record CreateFamilyMemberCommand : IRequest<MessageResponse>
{
    public string? Name { get; set; }
    public string? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public GenderStatus Gender { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Relationship { get; set; }
    public string? Note { get; set; }
    public int ElderId { get; set; }
}
