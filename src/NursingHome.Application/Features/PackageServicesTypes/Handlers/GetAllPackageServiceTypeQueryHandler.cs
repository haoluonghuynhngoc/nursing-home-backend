using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageServicesTypes.Models;
using NursingHome.Application.Features.PackageServicesTypes.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageServicesTypes.Handlers;
internal sealed class GetAllPackageServiceTypeQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllPackageServiceTypeQuery, PaginatedResponse<PackageServiceTypeResponse>>
{
    private readonly IGenericRepository<PackageServiceType> _packageServiceTypeRepository = unitOfWork.Repository<PackageServiceType>();
    public async Task<PaginatedResponse<PackageServiceTypeResponse>> Handle(GetAllPackageServiceTypeQuery request, CancellationToken cancellationToken)
    {
        var paginPackageServiceType = await _packageServiceTypeRepository.FindAsync<PackageServiceTypeResponse>(
            pageIndex: request.PageNumber,
            pageSize: request.PageSize,
            expression: x =>
                (string.IsNullOrEmpty(request.Search) || string.IsNullOrEmpty(x.Name) || x.Name.Contains(request.Search)),
            orderBy: x => x.OrderByDescending(x => x.Id),
            cancellationToken: cancellationToken
            );
        return await paginPackageServiceType.ToPaginatedResponseAsync();
    }
}
