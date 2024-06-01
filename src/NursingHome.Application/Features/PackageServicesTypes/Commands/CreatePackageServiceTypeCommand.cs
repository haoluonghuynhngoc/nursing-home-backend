using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.PackageServicesTypes.Commands;
public sealed record CreatePackageServiceTypeCommand : IRequest<MessageResponse>
{
    public string? Name { get; set; }
}
