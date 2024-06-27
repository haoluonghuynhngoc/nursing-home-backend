using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Notifications.Commands;
public sealed record UpdateNotificationStatusCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }

    public bool IsRead { get; set; }
}
