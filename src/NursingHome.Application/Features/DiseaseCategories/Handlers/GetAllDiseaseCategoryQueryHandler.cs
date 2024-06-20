using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.DiseaseCategories.Models;
using NursingHome.Application.Features.DiseaseCategories.Queries;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.DiseaseCategories.Handlers;
internal sealed class GetAllDiseaseCategoryQueryHandler(
    IUnitOfWork unitOfWork) : IRequestHandler<GetAllDiseaseCategoryQuery, PaginatedResponse<DiseaseCategoryResponse>>
{
    private readonly IGenericRepository<DiseaseCategory> _diseaseCategoryRepository = unitOfWork.Repository<DiseaseCategory>();
    public async Task<PaginatedResponse<DiseaseCategoryResponse>> Handle(GetAllDiseaseCategoryQuery request, CancellationToken cancellationToken)
    {
        var paginListBlock = await _diseaseCategoryRepository.FindAsync<DiseaseCategoryResponse>(
           pageIndex: request.PageIndex,
           pageSize: request.PageSize,
           expression: request.GetExpressions(),
           orderBy: request.GetOrder(),
           cancellationToken: cancellationToken
           );
        return await paginListBlock.ToPaginatedResponseAsync();
    }
}