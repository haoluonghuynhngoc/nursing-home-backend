using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackageCategories.Models;
using NursingHome.Application.Features.ServicePackageCategories.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.ServicePackageCategories.Handlers;
internal sealed class GetPackageCategoriesByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetPackageCategoriesByIdQuery, PackageCategoryResponse>
{
    private readonly IGenericRepository<ServicePackageCategory> _packageCategoryRepository = unitOfWork.Repository<ServicePackageCategory>();
    public async Task<PackageCategoryResponse> Handle(GetPackageCategoriesByIdQuery request, CancellationToken cancellationToken)
    {
        var packageCategory = await _packageCategoryRepository.FindByAsync<PackageCategoryResponse>(x => x.Id == request.Id)
        ?? throw new NotFoundException($" Package Category Have Id {request.Id} Is Not Found");

        return packageCategory;
    }
}
