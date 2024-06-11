using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Feedbacks.Commands;
public sealed record DeleteFeedbackCommand(int Id) : IRequest<MessageResponse>;

