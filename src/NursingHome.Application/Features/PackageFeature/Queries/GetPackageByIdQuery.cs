using MediatR;
using NursingHome.Application.Features.PackageFeature.Models;

namespace NursingHome.Application.Features.PackageFeature.Queries;
public record GetPackageByIdQuery(int Id) : IRequest<PackageResponse>;