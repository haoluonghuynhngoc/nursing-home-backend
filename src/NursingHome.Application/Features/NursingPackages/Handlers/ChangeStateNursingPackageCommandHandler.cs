using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.NursingPackages.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.NursingPackages.Handlers;
internal class ChangeStateNursingPackageCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeStateNursingPackageCommand, MessageResponse>
{
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();

    public async Task<MessageResponse> Handle(ChangeStateNursingPackageCommand request, CancellationToken cancellationToken)
    {
        var nursingPackage = await _nursingPackageRepository
          .FindByAsync(x => x.Id == request.Id
         , includeFunc: _ => _.Include(x => x.Rooms), cancellationToken: cancellationToken);
        if (nursingPackage is null)
        {
            throw new NotFoundException(nameof(NursingPackage), request.Id);
        }

        request.Adapt(nursingPackage);
        await _nursingPackageRepository.UpdateAsync(nursingPackage);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
