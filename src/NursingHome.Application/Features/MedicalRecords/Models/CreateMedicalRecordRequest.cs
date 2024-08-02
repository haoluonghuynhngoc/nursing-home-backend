using NursingHome.Application.Features.DiseaseCategories.Models;

namespace NursingHome.Application.Features.MedicalRecords.Models;

public record CreateMedicalRecordRequest
{
    public string? BloodType { get; set; }
    public string? Weight { get; set; }
    public string? Move { get; set; }
    public string? Height { get; set; }
    public string? UnderlyingDisease { get; set; }
    public string? Note { get; set; }
    public ICollection<CreateDiseaseCategoriesRequest> DiseaseCategories { get; set; } = new HashSet<CreateDiseaseCategoriesRequest>();
}
