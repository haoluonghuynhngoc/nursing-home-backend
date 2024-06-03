using MediatR;
using NursingHome.Application.Features.PackageRegisterTypes.Models;

namespace NursingHome.Application.Features.PackageRegisterTypes.Queries;
public sealed record GetByIdPackageRegisterTypeQuery(int Id) : IRequest<PackageRegisterTypeResponse>;
