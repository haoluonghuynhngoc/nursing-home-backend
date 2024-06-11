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
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    private readonly IGenericRepository<PackageCategory> _packageCategoryRepository = unitOfWork.Repository<PackageCategory>();

    public async Task<MessageResponse> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
    {
        if (!await _packageCategoryRepository.ExistsByAsync(_ => _.Id == request.PackageCategoryId, cancellationToken))
        {
            throw new NotFoundException(nameof(PackageCategory), request.PackageCategoryId);
        }

        var package = request.Adapt<Package>();
        await _packageRepository.CreateAsync(package, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
