using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.HealthReportCategories.Models;
using NursingHome.Application.Features.HealthReportCategories.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.HealthReportCategories.Handlers;
internal sealed class GetCategoryByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetCategoryByIdQuery, ReportCategoryResponse>
{
    private readonly IGenericRepository<HealthReportCategory> _categoryRepository = unitOfWork.Repository<HealthReportCategory>();
    public async Task<ReportCategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var healthCateroty = await _categoryRepository.FindByAsync<ReportCategoryResponse>(x => x.Id == request.Id)
          ?? throw new NotFoundException($"Health Category Have Id {request.Id} Is Not Found");
        return healthCateroty;
    }
}
