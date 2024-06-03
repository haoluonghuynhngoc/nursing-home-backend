using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PackageRegister.Commands;
public sealed record UpdatePackageRegisterCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public int NumberBed { get; set; }
    public int LimitedRegistration { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public string? Currency { get; set; }
}
