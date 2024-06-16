using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.ServicePackageCategories.Commands;
public sealed record CreatePackageCategoriesCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
}
