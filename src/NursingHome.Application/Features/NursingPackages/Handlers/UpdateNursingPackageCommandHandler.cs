using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.NursingPackages.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.NursingPackages.Handlers;
internal class UpdateNursingPackageCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateNursingPackageCommand, MessageResponse>
{
    private readonly IGenericRepository<NursingPackage> _nursingPackageRepository = unitOfWork.Repository<NursingPackage>();

    public async Task<MessageResponse> Handle(UpdateNursingPackageCommand request, CancellationToken cancellationToken)
    {
        if (await _nursingPackageRepository.ExistsByAsync(_ => _.Name == request.Name))
        {
            throw new ConflictException($"Nursing Package Have Name {request.Name} In DataBase");
        }

        var nursingPackage = await _nursingPackageRepository
            .FindByAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (nursingPackage is null)
        {
            throw new NotFoundException(nameof(NursingPackage), request.Id);
        }
        // cập nhật gói thì nhớ check xem số lượng giường trong phòng phải được cập nhật theo 
        request.Adapt(nursingPackage);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
