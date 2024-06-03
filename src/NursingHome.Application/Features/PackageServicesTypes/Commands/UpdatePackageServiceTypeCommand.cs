using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PackageServicesTypes.Commands;
public sealed record UpdatePackageServiceTypeCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? NameService { get; set; }
}
