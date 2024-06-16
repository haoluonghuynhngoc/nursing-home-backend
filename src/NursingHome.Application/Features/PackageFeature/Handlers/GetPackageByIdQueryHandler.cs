using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageFeature.Models;
using NursingHome.Application.Features.PackageFeature.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageFeature.Handlers;
internal class GetPackageByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPackageByIdQuery, ServicePackageResponse>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();
    public async Task<ServicePackageResponse> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
    {
        var package = await _servicePackageRepository.FindByAsync<ServicePackageResponse>(x => x.Id == request.Id, cancellationToken);
        if (package == null)
        {
            throw new NotFoundException(nameof(ServicePackage), request.Id);
        }

        return package;

    }
}
