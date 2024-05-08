using NursingHome.Domain.Common.Interfaces;

namespace NursingHome.Domain.Common;
public class BaseEntity<TKey> : BaseDomainEvent, IEntity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; } = default!;

}
