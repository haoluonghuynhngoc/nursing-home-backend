using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class PackageCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    [Column(TypeName = "nvarchar(24)")]
    public PackageCategoryType Type { get; set; }
    public ICollection<Package> Packages { get; set; } = new HashSet<Package>();
}
