using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageFeature.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageFeature.Handlers;
internal class CreatePackageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreatePackageCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();
    private readonly IGenericRepository<ServicePackageCategory> _packageCategoryRepository = unitOfWork.Repository<ServicePackageCategory>();

    public async Task<MessageResponse> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
    {
        if (!await _packageCategoryRepository.ExistsByAsync(_ => _.Id == request.ServicePackageCategoryId, cancellationToken))
        {
            throw new NotFoundException(nameof(ServicePackageCategory), request.ServicePackageCategoryId);
        }

        var package = request.Adapt<ServicePackage>();
        await _servicePackageRepository.CreateAsync(package, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
