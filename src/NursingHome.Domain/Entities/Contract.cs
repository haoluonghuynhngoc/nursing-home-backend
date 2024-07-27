using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Contract : BaseAuditableEntity<int>
{
    public string Name { get; set; } = default!;
    public DateOnly SigningDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int Duration { get; set; }
    public decimal Price { get; set; }
    public string? Content { get; set; } = default!;
    //public string? ImageUrl { get; set; }
    public string? Notes { get; set; }
    public string? ReasonForCanceling { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public ContractStatus Status { get; set; } = default!;
    public string? Description { get; set; }
    public int ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public int? NursingPackageId { get; set; }
    public virtual NursingPackage NursingPackage { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    //public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
}
