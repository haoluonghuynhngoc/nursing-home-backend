using NursingHome.Domain.Common;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class PackageCategory : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    [Column(TypeName = "nvarchar(24)")]
    public PackageCategoryType Type { get; set; }
    public virtual ICollection<Package> Packages { get; set; } = new HashSet<Package>();
}
