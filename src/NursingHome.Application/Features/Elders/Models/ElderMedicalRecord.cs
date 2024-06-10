namespace NursingHome.Application.Features.Elders.Models;
public sealed record ElderMedicalRecord
{
    public Guid Id { get; set; }
    public string? BloodType { get; set; }
    public string? Weight { get; set; }
    public string? Height { get; set; }
    public string? UnderlyingDisease { get; set; }
    public string? Note { get; set; }
}
