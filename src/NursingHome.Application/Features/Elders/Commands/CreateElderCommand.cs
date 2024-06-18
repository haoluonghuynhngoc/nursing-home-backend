using MediatR;
using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Features.MedicalRecords.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Commands;
public sealed record CreateElderCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public string? DateOfBirth { get; set; }
    public string CCCD { get; set; } = default!;
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public string? Notes { get; set; }
    public int RoomId { get; set; }
    public Guid UserId { get; set; }
    public CreateMedicalRecordRequest MedicalRecord { get; set; } = default!;
    public CreateContractRequest Contract { get; set; } = default!;
}
