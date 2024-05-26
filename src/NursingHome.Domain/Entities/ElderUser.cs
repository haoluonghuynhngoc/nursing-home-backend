using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class ElderUser
{
    public Guid ElderId { get; set; }
    public virtual Elder Elder { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    // trực ngày mấy

}
