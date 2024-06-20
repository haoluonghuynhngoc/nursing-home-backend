using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class DiseaseCategory : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new HashSet<MedicalRecord>();
}
