using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Elders.Commands;
public sealed record CreateElderCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public Guid UserCustomerId { get; set; }
    [JsonIgnore]
    public Guid PackageRegisterId { get; set; }
    [JsonIgnore]
    public int RoomId { get; set; }
    public string? RelationshipElderWithCustomer { get; set; }
    public DateTime UserPackageDay { get; set; }
    public string? FullName { get; set; }
    public string? IdentityNumber { get; set; }
    public string? DateOfBirth { get; set; }
    public GenderStatus Gender { get; set; } = GenderStatus.Male;
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string? Notes { get; set; }
    public DateTime InDate { get; set; }
    public DateTime OutDate { get; set; }
}
