using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.DiseaseCategories.Commands;
public sealed record CreateDiseaseCategoryCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
}
