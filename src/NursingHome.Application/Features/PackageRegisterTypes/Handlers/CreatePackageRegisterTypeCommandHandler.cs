using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageRegisterTypes.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageRegisterTypes.Handlers;
internal sealed class CreatePackageRegisterTypeCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreatePackageRegisterTypeCommand, MessageResponse>
{
    private readonly IGenericRepository<PackageRegisterType> _packageRegisterTypeRepository = unitOfWork.Repository<PackageRegisterType>();
    public async Task<MessageResponse> Handle(CreatePackageRegisterTypeCommand request, CancellationToken cancellationToken)
    {
        var packageRegisterTypeDb = await _packageRegisterTypeRepository.FindByAsync(_ => _.NameRegister == request.NameRegister);
        if (packageRegisterTypeDb != null)
        {
            throw new BadRequestException($"Package Register Type In Data Base Have Name {request.NameRegister}");
        }
        var packageRegisterType = new PackageRegisterType
        {
            NameRegister = request.NameRegister
        };
        await _packageRegisterTypeRepository.CreateAsync(packageRegisterType);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
