using NursingHome.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class ServicePackageCategory : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    [Column(TypeName = "nvarchar(24)")]
    public virtual ICollection<ServicePackage> ServicePackages { get; set; } = new HashSet<ServicePackage>();
}
