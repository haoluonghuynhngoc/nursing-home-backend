using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Payment : BaseEntity<Guid>
{
    public double Amount { get; set; }
    public string? Currency { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public TransactionMethod Method { get; set; }
    public string? Note { get; set; }
    public Guid BillId { get; set; }
    public virtual Bill Bill { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
}
