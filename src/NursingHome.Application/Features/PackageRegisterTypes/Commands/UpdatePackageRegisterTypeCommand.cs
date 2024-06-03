using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PackageRegisterTypes.Commands;
public sealed record UpdatePackageRegisterTypeCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? NameRegister { get; set; }
}