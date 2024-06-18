using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Feedbacks.Commands;
public sealed record UpdateFeedbackCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int? Rating { get; set; }
    public string? Content { get; set; }
}
