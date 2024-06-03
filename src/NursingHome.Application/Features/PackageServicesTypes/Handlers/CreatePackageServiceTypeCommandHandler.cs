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
        var packageServiceTypeDb = await _packageServiceTypeRepository.FindByAsync(_ => _.NameService == request.NameService);
        if (packageServiceTypeDb != null)
        {
            throw new BadRequestException($"Package Service Type In Data Base Have Name {request.NameService}");
        }
        var packageServiceType = new PackageServiceType
        {
            NameService = request.NameService
        };
        await _packageServiceTypeRepository.CreateAsync(packageServiceType);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
