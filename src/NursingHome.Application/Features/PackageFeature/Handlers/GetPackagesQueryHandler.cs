using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageFeature.Models;
using NursingHome.Application.Features.PackageFeature.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageFeature.Handlers;
internal class GetPackagesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPackagesQuery, PaginatedResponse<PackageResponse>>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    public async Task<PaginatedResponse<PackageResponse>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
    {
        var packages = await _packageRepository
            .FindAsync<PackageResponse>(
                request.PageIndex,
                request.PageSize,
                request.GetExpressions(),
                request.GetOrder(),
                cancellationToken);

        return await packages.ToPaginatedResponseAsync();
    }
}
