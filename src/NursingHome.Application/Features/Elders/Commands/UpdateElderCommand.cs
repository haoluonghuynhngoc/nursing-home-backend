using MediatR;
using NursingHome.Application.Features.MedicalRecords.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Elders.Commands;
public record UpdateElderCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Name { get; set; } = default!;
    public string? DateOfBirth { get; set; }
    public string CCCD { get; set; } = default!;
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public string? Habits { get; set; }
    public string? Relationship { get; set; }
    public string? Notes { get; set; }
    public int NursingPackageId { get; set; }
    public int RoomId { get; set; }
    public Guid UserId { get; set; }
    public UpdateMedicalRecordRequest MedicalRecord { get; set; } = default!;
}
