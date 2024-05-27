using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class NurseElder : BaseAuditableEntity<Guid>
{
    public DateTime DutyDay { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public NurseElderStatus Status { get; set; }
    public Guid? ElderId { get; set; }
    public Elder Elder { get; set; } = default!;
    public Guid? UserId { get; set; }
    public User User { get; set; } = default!;
}
