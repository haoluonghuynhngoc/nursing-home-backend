using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageRegisterTypes.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageRegisterTypes.Handlers;
internal class UpdatePackageRegisterTypeCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdatePackageRegisterTypeCommand, MessageResponse>
{
    private readonly IGenericRepository<PackageRegisterType> _packageRegisterTypeRepository = unitOfWork.Repository<PackageRegisterType>();
    public async Task<MessageResponse> Handle(UpdatePackageRegisterTypeCommand request, CancellationToken cancellationToken)
    {
        var packageRegisterTypeDb = await _packageRegisterTypeRepository.FindByAsync(_ => _.NameRegister == request.NameRegister);
        if (packageRegisterTypeDb != null)
        {
            throw new BadRequestException($"Package Register Type In Data Base Have Name {request.NameRegister}");
        }
        var packageRegisterType = await _packageRegisterTypeRepository.FindByAsync(
             expression: _ => _.Id == request.Id)
            ?? throw new NotFoundException($"Package Type Have Id {request.Id} Is Not Found");
        request.Adapt(packageRegisterType);
        await _packageRegisterTypeRepository.UpdateAsync(packageRegisterType);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
