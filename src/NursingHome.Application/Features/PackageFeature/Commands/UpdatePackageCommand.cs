using MediatR;
using NursingHome.Application.Features.PackageFeature.Models;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PackageFeature.Commands;
public record UpdatePackageCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    public string? ImageUrl { get; set; }
    public int Capacity { get; set; }
    //public PackageType Type { get; set; } = default!;
    public ICollection<UpdateServicePackageDateRequest> ServicePackageDates { get; set; } = new HashSet<UpdateServicePackageDateRequest>();
}
