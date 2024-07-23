using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackageCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.ServicePackageCategories.Handlers;
internal class ChangeStateServicePackageCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<ChangeStateServicePackageCategoryCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackageCategory> _packageCategoryRepository = unitOfWork.Repository<ServicePackageCategory>();

    public async Task<MessageResponse> Handle(ChangeStateServicePackageCategoryCommand request, CancellationToken cancellationToken)
    {
        var packageCategory = await _packageCategoryRepository.FindByAsync(
         expression: _ => _.Id == request.Id)
          ?? throw new NotFoundException(nameof(ServicePackageCategory), request.Id);
        request.Adapt(packageCategory);

        await _packageCategoryRepository.UpdateAsync(packageCategory);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
