using MediatR;

namespace NursingHome.Domain.Common;
public abstract record BaseEvent : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    public Guid UserId { get; set; }
}

