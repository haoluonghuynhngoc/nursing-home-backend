using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.HealthReportCategories.Commands;
public sealed record CreateCategoryCommand : IRequest<MessageResponse>
{
    public string? Name { get; set; }
}
