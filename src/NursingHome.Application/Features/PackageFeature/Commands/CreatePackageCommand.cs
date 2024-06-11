using MediatR;
using NursingHome.Application.Features.PackageFeature.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageFeature.Commands;
public record CreatePackageCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    public string? ImageUrl { get; set; }
    public int Capacity { get; set; }
    public PackageType Type { get; set; } = default!;
    public int PackageCategoryId { get; set; }
    public ICollection<CreatePackageDateRequest> PackageDates { get; set; } = new HashSet<CreatePackageDateRequest>();
}
