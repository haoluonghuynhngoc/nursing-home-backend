using Mapster;
using MediatR;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageCategories.Handlers;
internal sealed class CreatePackageCategoriesCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreatePackageCategoriesCommand, MessageResponse>
{
    private readonly IGenericRepository<PackageCategory> _packageCategoryRepository = unitOfWork.Repository<PackageCategory>();
    public async Task<MessageResponse> Handle(CreatePackageCategoriesCommand request, CancellationToken cancellationToken)
    {
        var packageCategory = new PackageCategory();
        request.Adapt(packageCategory);

        await _packageCategoryRepository.CreateAsync(packageCategory);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
