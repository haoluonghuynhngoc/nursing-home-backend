using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthCategories.Models;
using NursingHome.Application.Features.HealthCategories.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.HealthCategories.Handlers;
internal class GetAllHealthCategoryQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllHealthCategoryQuery, PaginatedResponse<HealthCategoryResponse>>
{
    private readonly IGenericRepository<HealthCategory> _healthCategoryRepository = unitOfWork.Repository<HealthCategory>();
    public async Task<PaginatedResponse<HealthCategoryResponse>> Handle(GetAllHealthCategoryQuery request, CancellationToken cancellationToken)
    {
        var paginFeedBack = await _healthCategoryRepository.FindAsync<HealthCategoryResponse>(
           pageIndex: request.PageIndex,
           pageSize: request.PageSize,
           expression: request.GetExpressions(),
           orderBy: request.GetOrder(),
           cancellationToken: cancellationToken
           );
        return await paginFeedBack.ToPaginatedResponseAsync();
    }
}
