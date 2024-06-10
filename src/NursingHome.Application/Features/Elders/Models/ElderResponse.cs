using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Models;
public sealed record ElderResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string DateOfBirth { get; set; } = default!;
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public ElderStatus Status { get; set; }
    public string? Notes { get; set; }
    public ElderRoom Room { get; set; } = default!;
    public ElderUser User { get; set; } = default!;
    public ElderMedicalRecord MedicalRecord { get; set; } = default!;
    public IEnumerable<ElderNursingPackages> NursingPackages = default!;
}
