namespace NursingHome.Application.Features.Beds.Models;
public sealed record BedResponse
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public BedElderResponse? Elder { get; set; }
}
