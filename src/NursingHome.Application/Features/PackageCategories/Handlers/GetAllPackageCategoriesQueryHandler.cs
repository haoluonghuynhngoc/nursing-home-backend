using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageCategories.Models;
using NursingHome.Application.Features.PackageCategories.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageCategories.Handlers;
internal sealed class GetAllPackageCategoriesQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllPackageCategoriesQuery, PaginatedResponse<PackageCategoryResponse>>
{
    private readonly IGenericRepository<PackageCategory> _packageCategoryRepository = unitOfWork.Repository<PackageCategory>();
    public async Task<PaginatedResponse<PackageCategoryResponse>> Handle(GetAllPackageCategoriesQuery request, CancellationToken cancellationToken)
    {
        var listPackageCategory = await _packageCategoryRepository.FindAsync<PackageCategoryResponse>(
               pageIndex: request.PageIndex,
               pageSize: request.PageSize,
               request.GetExpressions(),
               orderBy: request.GetOrder(),
               cancellationToken: cancellationToken
               );

        return await listPackageCategory.ToPaginatedResponseAsync();
    }
}
