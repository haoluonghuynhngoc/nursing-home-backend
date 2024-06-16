using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageFeature.Models;
using NursingHome.Application.Features.PackageFeature.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageFeature.Handlers;
internal class GetPackagesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPackagesQuery, PaginatedResponse<ServicePackageResponse>>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();
    public async Task<PaginatedResponse<ServicePackageResponse>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
    {
        var packages = await _servicePackageRepository
            .FindAsync<ServicePackageResponse>(
                request.PageIndex,
                request.PageSize,
                request.GetExpressions(),
                request.GetOrder(),
                cancellationToken);

        return await packages.ToPaginatedResponseAsync();
    }
}
