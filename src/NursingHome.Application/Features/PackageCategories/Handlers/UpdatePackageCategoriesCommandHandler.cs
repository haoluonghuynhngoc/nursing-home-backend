using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageCategories.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageCategories.Handlers;
internal sealed class UpdatePackageCategoriesCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdatePackageCategoriesCommand, MessageResponse>
{
    private readonly IGenericRepository<PackageCategory> _packageCategoryRepository = unitOfWork.Repository<PackageCategory>();
    public async Task<MessageResponse> Handle(UpdatePackageCategoriesCommand request, CancellationToken cancellationToken)
    {
        var packageCategory = await _packageCategoryRepository.FindByAsync(
          expression: _ => _.Id == request.Id)
           ?? throw new NotFoundException(nameof(PackageCategory), request.Id);
        request.Adapt(packageCategory);

        await _packageCategoryRepository.UpdateAsync(packageCategory);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
