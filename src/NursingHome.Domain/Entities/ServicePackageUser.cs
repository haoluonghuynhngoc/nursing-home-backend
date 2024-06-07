using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class ServicePackageUser
{
    public Guid ServicePackageId { get; set; }
    public virtual ServicePackage ServicePackage { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
}
