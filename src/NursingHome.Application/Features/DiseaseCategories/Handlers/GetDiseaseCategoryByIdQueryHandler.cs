using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.DiseaseCategories.Models;
using NursingHome.Application.Features.DiseaseCategories.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.DiseaseCategories.Handlers;
internal sealed class GetDiseaseCategoryByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetDiseaseCategoryByIdQuery, DiseaseCategoryResponse>
{
    private readonly IGenericRepository<DiseaseCategory> _diseaseCategoryRepository = unitOfWork.Repository<DiseaseCategory>();
    public async Task<DiseaseCategoryResponse> Handle(GetDiseaseCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var diseaseCategory = await _diseaseCategoryRepository.FindByAsync<DiseaseCategoryResponse>(x => x.Id == request.Id)
        ?? throw new NotFoundException($"Disease Category Have Id {request.Id} Is Not Found");
        return diseaseCategory;
    }
}
