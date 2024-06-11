using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.HealthCategories.Commands;
public sealed record CreateHealthCategoryCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public string? ImageUrl { get; set; } = default!;
    public string? Description { get; set; }
}
