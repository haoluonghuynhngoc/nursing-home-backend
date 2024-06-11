using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.PackageFeature.Commands;
public record DeletePackageCommand(int Id) : IRequest<MessageResponse>;