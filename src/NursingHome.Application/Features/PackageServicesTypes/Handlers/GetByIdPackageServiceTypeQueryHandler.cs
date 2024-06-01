using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageServicesTypes.Models;
using NursingHome.Application.Features.PackageServicesTypes.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageServicesTypes.Handlers;
internal sealed class GetByIdPackageServiceTypeQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetByIdPackageServiceTypeQuery, PackageServiceTypeResponse>
{
    private readonly IGenericRepository<PackageServiceType> _packageServiceTypeRepository = unitOfWork.Repository<PackageServiceType>();
    public async Task<PackageServiceTypeResponse> Handle(GetByIdPackageServiceTypeQuery request, CancellationToken cancellationToken)
    {
        var packageServiceType = await _packageServiceTypeRepository.FindByAsync<PackageServiceTypeResponse>(x => x.Id == request.Id)
          ?? throw new NotFoundException($"Package Type Have Id {request.Id} Is Not Found");
        return packageServiceType;
    }
}
