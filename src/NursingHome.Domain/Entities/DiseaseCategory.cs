using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class DiseaseCategory : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    [Column(TypeName = "nvarchar(24)")]
    public StateType State { get; set; }
    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new HashSet<MedicalRecord>();
}
