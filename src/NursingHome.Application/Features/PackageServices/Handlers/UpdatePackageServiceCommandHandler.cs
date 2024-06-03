using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.PackageServices.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageServices.Handlers;
internal sealed class UpdatePackageServiceCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<UpdatePackageServiceCommand, MessageResponse>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    private readonly IGenericRepository<PackageServiceType> _packageServicesTypesRepository = unitOfWork.Repository<PackageServiceType>();
    public async Task<MessageResponse> Handle(UpdatePackageServiceCommand request, CancellationToken cancellationToken)
    {
        var package = await _packageRepository.FindByAsync(_ => _.Id == request.Id)
            ?? throw new NotFoundException($"Package Have Id {request.Id} Is Not Found");
        if (request.PackageServiceTypes != null)
        {
            // có thể xảy ra lỗi ở đây nếu lỗi thì cho nó 1 cái List<Hasset>
            package.PackageServiceTypes.Clear();
            foreach (var item in request.PackageServiceTypes)
            {
                package.PackageServiceTypes.Add(await _packageServicesTypesRepository.FindByAsync(_ => _.Id == item)
                 ?? throw new NotFoundException($"Package Service Type Have Id {item} Is Not Found"));
            }
        }

        request.Adapt(package);
        await _packageRepository.UpdateAsync(package);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
