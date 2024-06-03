using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.PackageRegisterTypes.Commands;
public sealed record CreatePackageRegisterTypeCommand : IRequest<MessageResponse>
{
    public string? NameRegister { get; set; }
}

