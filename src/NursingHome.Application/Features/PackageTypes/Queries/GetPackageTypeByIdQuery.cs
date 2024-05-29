using MediatR;
using NursingHome.Application.Features.PackageTypes.Models;

namespace NursingHome.Application.Features.PackageTypes.Queries;
public sealed record GetPackageTypeByIdQuery(int Id) : IRequest<PackageTypeResponse>;

