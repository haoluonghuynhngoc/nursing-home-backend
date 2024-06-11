using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthCategories.Models;
using NursingHome.Application.Features.HealthCategories.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthCategories.Handlers;
internal class GetHealthCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetHealthCategoryByIdQuery, HealthCategoryResponse>
{
    private readonly IGenericRepository<HealthCategory> _healthCategoryRepository = unitOfWork.Repository<HealthCategory>();
    public async Task<HealthCategoryResponse> Handle(GetHealthCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var healthCategory = await _healthCategoryRepository.FindByAsync<HealthCategoryResponse>(x => x.Id == request.Id)
           ?? throw new NotFoundException($"Health Category Have Id {request.Id} Is Not Found");
        return healthCategory;
    }
}
