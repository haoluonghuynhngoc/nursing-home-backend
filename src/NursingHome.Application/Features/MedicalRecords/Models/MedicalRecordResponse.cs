using NursingHome.Application.Features.Elders.Models;

namespace NursingHome.Application.Features.MedicalRecords.Models;
public record MedicalRecordResponse : BaseMedicalRecordResponse
{
    public BaseElderResponse Elder { get; set; } = default!;
    //public ICollection<BaseDiseaseCategoryResponse>? DiseaseCategories { get; set; } = new HashSet<BaseDiseaseCategoryResponse>();
}
