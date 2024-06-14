using MediatR;
using NursingHome.Application.Features.NursingPackages.Models;

namespace NursingHome.Application.Features.NursingPackages.Queries;
public record GetNursingPackageByIdQuery(int Id) : IRequest<NursingPackageResponse>;