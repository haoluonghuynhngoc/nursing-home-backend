using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackageCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ServicePackageCategories.Handlers;
internal class ChangeStateServicePackageCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<ChangeStateServicePackageCategoryCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackageCategory> _packageCategoryRepository = unitOfWork.Repository<ServicePackageCategory>();

    public async Task<MessageResponse> Handle(ChangeStateServicePackageCategoryCommand request, CancellationToken cancellationToken)
    {
        var packageCategory = await _packageCategoryRepository.FindByAsync(
         expression: _ => _.Id == request.Id, includeFunc: _ => _.Include(x => x.ServicePackages))
          ?? throw new NotFoundException(nameof(ServicePackageCategory), request.Id);

        if (packageCategory.ServicePackages.Count(_ => _.State == StateType.Active) > 0)
        {
            throw new FieldResponseException(627, "The service package cannot remove because it is currently in use.");
        }
        request.Adapt(packageCategory);

        await _packageCategoryRepository.UpdateAsync(packageCategory);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
