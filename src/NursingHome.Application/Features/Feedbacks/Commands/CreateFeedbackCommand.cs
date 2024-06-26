﻿using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Feedbacks.Commands;
public sealed record CreateFeedbackCommand : IRequest<MessageResponse>
{
    public string Title { get; set; } = default!;
    public RatingStatus Ratings { get; set; }
    public string? Content { get; set; }
    public int OrderDetailId { get; set; }
    [JsonIgnore]
    public Guid UserId { get; set; }

}
