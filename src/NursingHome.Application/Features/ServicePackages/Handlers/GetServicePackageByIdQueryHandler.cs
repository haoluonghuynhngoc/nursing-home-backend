using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackages.Models;
using NursingHome.Application.Features.ServicePackages.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.ServicePackages.Handlers;
internal class GetServicePackageByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetServicePackageByIdQuery, ServicePackageResponse>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();

    public async Task<ServicePackageResponse> Handle(GetServicePackageByIdQuery request, CancellationToken cancellationToken)
    {
        var package = await _servicePackageRepository.FindByAsync<ServicePackageResponse>(x => x.Id == request.Id, cancellationToken);
        if (package == null)
        {
            throw new NotFoundException(nameof(ServicePackage), request.Id);
        }
        return package;
    }
}
