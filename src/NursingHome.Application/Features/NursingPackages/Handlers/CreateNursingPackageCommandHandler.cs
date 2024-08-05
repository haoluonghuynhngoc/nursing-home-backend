using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.NursingPackages.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.NursingPackages.Handlers;
internal class CreateNursingPackageCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateNursingPackageCommand, MessageResponse>
{
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();

    public async Task<MessageResponse> Handle(CreateNursingPackageCommand request, CancellationToken cancellationToken)
    {
        // có thể sai logic ở đây : && _.State == StateType.Active
        if (await _nursingPackageRepository.ExistsByAsync(_ => _.Name == request.Name && _.State == StateType.Active))
        {
            throw new ConflictException($"Nursing Package Have Name {request.Name} In DataBase");
        }
        var nursingPackage = request.Adapt<NursingPackage>();
        //nursingPackage.Capacity *= 3;
        nursingPackage.State = StateType.Active;
        await _nursingPackageRepository.CreateAsync(nursingPackage, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.CreatedSuccess);
    }
}
