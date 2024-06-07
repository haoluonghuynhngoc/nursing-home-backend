using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class NursingPackageUser
{
    public Guid NursingPackageId { get; set; }
    public virtual NursingPackage NursingPackage { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
}
