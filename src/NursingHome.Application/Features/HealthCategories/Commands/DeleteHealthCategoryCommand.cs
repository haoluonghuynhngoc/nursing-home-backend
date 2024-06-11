using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.HealthCategories.Commands;
public sealed record DeleteHealthCategoryCommand(int Id) : IRequest<MessageResponse>;