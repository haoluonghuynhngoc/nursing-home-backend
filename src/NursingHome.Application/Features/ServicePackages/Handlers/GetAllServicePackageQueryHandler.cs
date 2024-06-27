using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackages.Models;
using NursingHome.Application.Features.ServicePackages.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.ServicePackages.Handlers;
internal class GetAllServicePackageQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllServicePackageQuery, PaginatedResponse<ServicePackageResponse>>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();

    public async Task<PaginatedResponse<ServicePackageResponse>> Handle(GetAllServicePackageQuery request, CancellationToken cancellationToken)
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
