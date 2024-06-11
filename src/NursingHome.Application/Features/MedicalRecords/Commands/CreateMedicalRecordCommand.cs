using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.MedicalRecords.Commands;
public record CreateMedicalRecordCommand : IRequest<MessageResponse>
{
    public string? BloodType { get; set; }
    public string? Weight { get; set; }
    public string? Height { get; set; }
    public string? UnderlyingDisease { get; set; }
    public string? Note { get; set; }
    public int ElderId { get; set; }
}
