using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReportCategories.Models;
using NursingHome.Application.Features.HealthReportCategories.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.HealthReportCategories.Handlers;
internal sealed class GetAllCategoryQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllCategoryQuery, PaginatedResponse<ReportCategoryResponse>>
{
    private readonly IGenericRepository<HealthReportCategory> _categoryRepository = unitOfWork.Repository<HealthReportCategory>();
    public async Task<PaginatedResponse<ReportCategoryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var paginListHealthCategory = await _categoryRepository.FindAsync<ReportCategoryResponse>(
             pageIndex: request.PageNumber,
             pageSize: request.PageSize,
             expression: x =>
                 (string.IsNullOrEmpty(request.Search) || x.Name.Contains(request.Search)),
             orderBy: x => x.OrderByDescending(x => x.Id),
             cancellationToken: cancellationToken
             );
        return await paginListHealthCategory.ToPaginatedResponseAsync();
    }
}
