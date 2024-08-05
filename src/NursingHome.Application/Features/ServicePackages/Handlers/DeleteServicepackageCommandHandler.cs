using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackages.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.ServicePackages.Handlers;
internal class DeleteServicepackageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteServicepackageCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();

    public async Task<MessageResponse> Handle(DeleteServicepackageCommand request, CancellationToken cancellationToken)
    {
        var package = await _servicePackageRepository.FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (package is null)
        {
            throw new NotFoundException(nameof(ServicePackage), request.Id);
        }
        package.State = StateType.Deleted;
        // await _servicePackageRepository.DeleteAsync(package);
        await _servicePackageRepository.UpdateAsync(package);
        await unitOfWork.CommitAsync(cancellationToken);
        return new MessageResponse(Resource.DeletedSuccess);
    }
}
