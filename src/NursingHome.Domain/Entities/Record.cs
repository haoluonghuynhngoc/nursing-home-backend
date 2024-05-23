using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class Record : BaseEntity<Guid>
{
    // chưa cần sài 
    public string? BloodType { get; set; }
    public string? Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public string? Status { get; set; }
    public string? Diagnosis { get; set; }
    public string? Treatment { get; set; }
    public string? Medication { get; set; }
    public string? Allergy { get; set; }
    public string? Note { get; set; }
}
