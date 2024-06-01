using MediatR;
using NursingHome.Application.Features.PackageServicesTypes.Models;

namespace NursingHome.Application.Features.PackageServicesTypes.Queries;
public sealed record GetByIdPackageServiceTypeQuery(int Id) : IRequest<PackageServiceTypeResponse>;
