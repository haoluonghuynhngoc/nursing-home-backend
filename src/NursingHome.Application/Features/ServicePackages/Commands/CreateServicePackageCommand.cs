using MediatR;
using NursingHome.Application.Features.ServicePackageDates.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ServicePackages.Commands;
public record CreateServicePackageCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string? Duration { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    public string? ImageUrl { get; set; }
    public PackageType Type { get; set; } = default!;
    public DateOnly EndDate { get; set; }
    public int ServicePackageCategoryId { get; set; }
    public virtual ICollection<CreateServicePackageDateRequest> ServicePackageDates { get; set; } = new HashSet<CreateServicePackageDateRequest>();
}
