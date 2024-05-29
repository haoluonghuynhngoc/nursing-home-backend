using MediatR;
using NursingHome.Application.Features.PackageRegister.Models;

namespace NursingHome.Application.Features.PackageRegister.Queries;
public sealed record GetPackageRegisterByIdQuery(Guid Id) : IRequest<PackageRegisterResponse>;
