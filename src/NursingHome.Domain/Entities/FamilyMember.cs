using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class FamilyMember : BaseAuditableEntity<int>
{
    public string? Name { get; set; }
    public string? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public GenderStatus Gender { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public StateType State { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Relationship { get; set; }
    public string? Note { get; set; }
    public int ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
}
