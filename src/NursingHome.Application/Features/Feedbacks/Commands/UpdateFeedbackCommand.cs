using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Feedbacks.Commands;
public sealed record UpdateFeedbackCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public RatingStatus Ratings { get; set; }
    public string? Content { get; set; }
}
