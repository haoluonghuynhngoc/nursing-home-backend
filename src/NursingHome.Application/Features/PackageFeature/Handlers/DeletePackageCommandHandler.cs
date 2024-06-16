using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageFeature.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageFeature.Handlers;
internal class DeletePackageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePackageCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();
    public async Task<MessageResponse> Handle(DeletePackageCommand request, CancellationToken cancellationToken)
    {
        var package = await _servicePackageRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (package is null)
        {
            throw new NotFoundException(nameof(ServicePackage), request.Id);
        }
        await _servicePackageRepository.DeleteAsync(package);
        await unitOfWork.CommitAsync(cancellationToken);
        return new MessageResponse(Resource.DeletedSuccess);
    }
}
