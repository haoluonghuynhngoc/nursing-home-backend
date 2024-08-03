using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackages.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.ServicePackages.Handlers;
internal class UpdateServicePackageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateServicePackageCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();
    private readonly IGenericRepository<ServicePackageCategory> _servicePackageCategoryRepository = unitOfWork.Repository<ServicePackageCategory>();
    public async Task<MessageResponse> Handle(UpdateServicePackageCommand request, CancellationToken cancellationToken)
    {
        if (!await _servicePackageCategoryRepository.ExistsByAsync(_ => _.Id != request.ServicePackageCategoryId))
        {
            throw new FieldResponseException(620, "Service Package Category Is Not Found");
        }

        var package = await _servicePackageRepository
            .FindByAsync(
                x => x.Id == request.Id,
                _ => _.Include(_ => _.ServicePackageDates),
            cancellationToken: cancellationToken);

        if (package is null)
        {
            throw new NotFoundException(nameof(ServicePackage), request.Id);
        }

        request.Adapt(package);
        await _servicePackageRepository.UpdateAsync(package);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
