using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageCategories.Models;
using NursingHome.Application.Features.PackageCategories.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageCategories.Handlers;
internal sealed class GetPackageCategoryByIdQueryHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetPackageCategoryByIdQuery, PackageCategoryResponse>
{
    private readonly IGenericRepository<PackageCategory> _packageCategoryRepository = unitOfWork.Repository<PackageCategory>();
    public async Task<PackageCategoryResponse> Handle(GetPackageCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var packageCategory = await _packageCategoryRepository.FindByAsync<PackageCategoryResponse>(x => x.Id == request.Id)
         ?? throw new NotFoundException($"Package Type Have Id {request.Id} Is Not Found");
        return packageCategory;
    }
}
