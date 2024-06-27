using MediatR;
using NursingHome.Application.Features.ServicePackages.Models;

namespace NursingHome.Application.Features.ServicePackages.Queries;
public record GetServicePackageByIdQuery(int Id) : IRequest<ServicePackageResponse>;
