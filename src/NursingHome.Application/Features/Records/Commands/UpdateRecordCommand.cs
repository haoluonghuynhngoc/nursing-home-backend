using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Records.Commands;
public sealed record UpdateRecordCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? BloodType { get; set; }
    public string? Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public string? CurrentMedications { get; set; }
    public string? Allergy { get; set; }
    public string? Note { get; set; }
}
