using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackages.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ServicePackages.Handlers;
internal class CreateServicePackageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateServicePackageCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();
    private readonly IGenericRepository<ServicePackageCategory> _packageCategoryRepository = unitOfWork.Repository<ServicePackageCategory>();

    public async Task<MessageResponse> Handle(CreateServicePackageCommand request, CancellationToken cancellationToken)
    {
        if (!await _packageCategoryRepository.ExistsByAsync(_ => _.Id == request.ServicePackageCategoryId, cancellationToken))
        {
            throw new NotFoundException(nameof(ServicePackageCategory), request.ServicePackageCategoryId);
        }

        var package = request.Adapt<ServicePackage>();
        package.State = StateType.Active;
        await _servicePackageRepository.CreateAsync(package, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
