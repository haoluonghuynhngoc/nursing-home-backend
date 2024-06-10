using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageCategories.Commands;
public sealed record CreatePackageCategoriesCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public PackageCategoryType Type { get; set; }
}
