using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class PackageType
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public PackageTypeName Name { get; set; }
    public virtual ICollection<Package> Packages { get; set; } = new HashSet<Package>();
}
