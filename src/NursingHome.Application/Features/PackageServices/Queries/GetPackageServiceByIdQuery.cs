using MediatR;
using NursingHome.Application.Features.PackageServices.Models;

namespace NursingHome.Application.Features.PackageServices.Queries;
public sealed record GetPackageServiceByIdQuery(Guid Id) : IRequest<PackageServiceResponse>;