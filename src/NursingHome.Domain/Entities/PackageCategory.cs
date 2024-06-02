using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class PackageCategory
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public PackageCategoryName Name { get; set; }
    public virtual ICollection<Package> Packages { get; set; } = new HashSet<Package>();
}
