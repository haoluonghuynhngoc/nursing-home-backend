using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PackageCategories.Commands;
public sealed record UpdatePackageCategoriesCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public PackageCategoryType Type { get; set; }
}
