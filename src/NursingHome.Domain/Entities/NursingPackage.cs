using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class NursingPackage : BaseAuditableEntity<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!; // sửa lại chổ này 
    [Column(TypeName = "nvarchar(24)")]
    public NursingPackageType Type { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public string? ImageUrl { get; set; }
    public int NumberOfNurses { get; set; }
    public int Capacity { get; set; }
    //[Projectable]
    //public int TotalOrder => Orders.Count;
    public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    //public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

}
