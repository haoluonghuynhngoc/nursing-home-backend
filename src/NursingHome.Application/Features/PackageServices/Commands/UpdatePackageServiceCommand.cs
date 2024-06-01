using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PackageServices.Commands;
public sealed record UpdatePackageServiceCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    [JsonIgnore]
    public List<int>? PackageServiceTypes { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? ImagePackage { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }
    public string? Currency { get; set; }
    public int DurationTime { get; set; }
}
