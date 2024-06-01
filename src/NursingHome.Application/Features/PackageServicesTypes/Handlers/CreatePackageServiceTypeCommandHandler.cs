using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageServicesTypes.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageServicesTypes.Handlers;
internal sealed class CreatePackageServiceTypeCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreatePackageServiceTypeCommand, MessageResponse>
{
    private readonly IGenericRepository<PackageServiceType> _packageServiceTypeRepository = unitOfWork.Repository<PackageServiceType>();
    public async Task<MessageResponse> Handle(CreatePackageServiceTypeCommand request, CancellationToken cancellationToken)
    {
        var packageRegisterType = await _packageServiceTypeRepository.FindByAsync(_ => _.Name == request.Name);
        if (packageRegisterType != null)
        {
            throw new BadRequestException($"Package Register Type In Data Base Have Name {request.Name}");
        }
        var packageServiceType = new PackageServiceType
        {
            Name = request.Name
        };
        await _packageServiceTypeRepository.CreateAsync(packageServiceType);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
