using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageTypes.Models;
using NursingHome.Application.Features.PackageTypes.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageTypes.Handlers;
internal sealed class GetAllPackageTypeQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllPackageTypeQuery, PaginatedResponse<PackageTypeResponse>>
{
    private readonly IGenericRepository<PackageType> _packageTypeRepository = unitOfWork.Repository<PackageType>();
    public async Task<PaginatedResponse<PackageTypeResponse>> Handle(GetAllPackageTypeQuery request, CancellationToken cancellationToken)
    {
        var paginListPackageType = await _packageTypeRepository.FindAsync<PackageTypeResponse>(
           pageIndex: request.PageNumber,
           pageSize: request.PageSize,
           expression: x =>
               (request.Search == null || x.Name == request.Search),
           orderBy: x => x.OrderBy(x => x.Name),
           cancellationToken: cancellationToken
           );
        return await paginListPackageType.ToPaginatedResponseAsync();
    }
}
