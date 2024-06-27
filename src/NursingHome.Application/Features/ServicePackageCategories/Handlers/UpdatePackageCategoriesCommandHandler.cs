using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackageCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.ServicePackageCategories.Handlers;
internal sealed class UpdatePackageCategoriesCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdatePackageCategoriesCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackageCategory> _packageCategoryRepository = unitOfWork.Repository<ServicePackageCategory>();
    public async Task<MessageResponse> Handle(UpdatePackageCategoriesCommand request, CancellationToken cancellationToken)
    {
        if (await _packageCategoryRepository.ExistsByAsync(x => x.Id != request.Id && x.Name == request.Name))
        {
            throw new ConflictException(nameof(ServicePackageCategory), request.Id);
        }

        var packageCategory = await _packageCategoryRepository.FindByAsync(
          expression: _ => _.Id == request.Id)
           ?? throw new NotFoundException(nameof(ServicePackageCategory), request.Id);
        request.Adapt(packageCategory);

        await _packageCategoryRepository.UpdateAsync(packageCategory);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
