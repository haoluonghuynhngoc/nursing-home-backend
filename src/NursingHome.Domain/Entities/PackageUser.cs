using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class PackageUser
{

    public Guid PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
}
