using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackageCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ServicePackageCategories.Handlers;
internal sealed class CreatePackageCategoriesCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreatePackageCategoriesCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackageCategory> _packageCategoryRepository = unitOfWork.Repository<ServicePackageCategory>();
    public async Task<MessageResponse> Handle(CreatePackageCategoriesCommand request, CancellationToken cancellationToken)
    {
        if (await _packageCategoryRepository.ExistsByAsync(_ => _.Name == request.Name && _.State == StateType.Active))
        {
            throw new ConflictException($"Package Category Have Name {request.Name} In DataBase");
        }

        var packageCategory = new ServicePackageCategory();
        request.Adapt(packageCategory);

        packageCategory.State = StateType.Active;
        await _packageCategoryRepository.CreateAsync(packageCategory);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
