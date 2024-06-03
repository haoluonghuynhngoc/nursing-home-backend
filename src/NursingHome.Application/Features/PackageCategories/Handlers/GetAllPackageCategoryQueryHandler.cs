using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageCategories.Models;
using NursingHome.Application.Features.PackageCategories.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageCategories.Handlers;
internal sealed class GetAllPackageCategoryQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllPackageCategoryQuery, PaginatedResponse<PackageCategoryResponse>>
{
    private readonly IGenericRepository<PackageCategory> _packageCategoryRepository = unitOfWork.Repository<PackageCategory>();
    public async Task<PaginatedResponse<PackageCategoryResponse>> Handle(GetAllPackageCategoryQuery request, CancellationToken cancellationToken)
    {
        var paginListCategories = await _packageCategoryRepository.FindAsync<PackageCategoryResponse>(
            pageIndex: request.PageNumber,
            pageSize: request.PageSize,
            expression: x =>
                (request.Search == null || x.Name == request.Search),
            orderBy: x => x.OrderBy(x => x.Name),
            cancellationToken: cancellationToken
            );
        return await paginListCategories.ToPaginatedResponseAsync();
    }
}
