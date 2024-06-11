using MediatR;
using NursingHome.Application.Features.Feedbacks.Models;

namespace NursingHome.Application.Features.Feedbacks.Queries;
public sealed record GetFeedbackByIdQuery(int Id) : IRequest<FeedbackResponse>;
