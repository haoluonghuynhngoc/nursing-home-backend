using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageServicesTypes.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageServicesTypes.Handlers;
internal sealed class UpdatePackageServiceTypeCommandHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdatePackageServiceTypeCommand, MessageResponse>
{
    private readonly IGenericRepository<PackageServiceType> _packageServiceTypeRepository = unitOfWork.Repository<PackageServiceType>();
    public async Task<MessageResponse> Handle(UpdatePackageServiceTypeCommand request, CancellationToken cancellationToken)
    {
        var packageServiceTypeDb = await _packageServiceTypeRepository.FindByAsync(_ => _.NameService == request.NameService);
        if (packageServiceTypeDb != null)
        {
            throw new BadRequestException($"Package Service Type In Data Base Have Name {request.NameService}");
        }
        var packageServiceType = await _packageServiceTypeRepository.FindByAsync(
             expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Package Type Have Id {request.Id} Is Not Found");
        request.Adapt(packageServiceType);
        await _packageServiceTypeRepository.UpdateAsync(packageServiceType);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
