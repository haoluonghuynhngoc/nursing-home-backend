using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.NursingPackages.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.NursingPackages.Handlers;
internal class UpdateNursingPackageCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateNursingPackageCommand, MessageResponse>
{
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();

    public async Task<MessageResponse> Handle(UpdateNursingPackageCommand request, CancellationToken cancellationToken)
    {
        // có thể sai logic ở đây : && _.State == StateType.Active
        if (await _nursingPackageRepository.ExistsByAsync(_ => _.Id != request.Id && _.Name == request.Name && _.State == StateType.Active))
        {
            throw new ConflictException($"Nursing Package Have Name {request.Name} In DataBase");
        }

        var nursingPackage = await _nursingPackageRepository
            .FindByAsync(x => x.Id == request.Id
            , includeFunc: _ => _.Include(x => x.Contracts), cancellationToken: cancellationToken);
        if (nursingPackage is null)
        {
            throw new NotFoundException(nameof(NursingPackage), request.Id);
        }

        if (nursingPackage.Contracts.Any(_ => _.Status != ContractStatus.Expired && _.Status != ContractStatus.Cancelled)
            && nursingPackage.Capacity != request.Capacity)
        {
            throw new FieldResponseException(621, "Nursing package cannot be edited because there is an active contract that cannot edit Capacity");
        }
        if (nursingPackage.Contracts.Any(_ => _.Status != ContractStatus.Expired && _.Status != ContractStatus.Cancelled)
            && nursingPackage.NumberOfNurses != request.NumberOfNurses)
        {
            throw new FieldResponseException(622, "Nursing package cannot be edited because there is an active contract that cannot edit Number Of Nurses");
        }

        request.Adapt(nursingPackage);
        await _nursingPackageRepository.UpdateAsync(nursingPackage);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
