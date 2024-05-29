using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Contract : BaseEntity<Guid>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Content { get; set; }
    public string? ImageContract { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public ContractStatus? Status { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public Guid ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
}