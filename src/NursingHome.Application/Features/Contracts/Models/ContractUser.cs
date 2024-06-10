using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Contracts.Models;
public sealed record ContractUser
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Address { get; set; }
    public string? CCCD { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public GenderStatus Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? DateOfBirth { get; set; }
}
