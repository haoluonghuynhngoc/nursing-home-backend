using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackageCategories.Models;
using NursingHome.Application.Features.ServicePackageCategories.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.ServicePackageCategories.Handlers;
internal sealed class GetAllPackageCategoriesQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetAllPackageCategoriesQuery, PaginatedResponse<PackageCategoryResponse>>
{
    private readonly IGenericRepository<ServicePackageCategory> _packageCategoryRepository = unitOfWork.Repository<ServicePackageCategory>();
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
