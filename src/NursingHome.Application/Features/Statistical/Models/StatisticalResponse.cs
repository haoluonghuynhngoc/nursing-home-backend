namespace NursingHome.Application.Features.Statistical.Models;
public record StatisticalResponse
{
    public int User { get; set; }
    public int Elder { get; set; }
    public decimal NursingPackage { get; set; }
    public decimal ServicePackage { get; set; }
}
