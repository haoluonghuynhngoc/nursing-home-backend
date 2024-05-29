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
    public async Task<MessageResponse> Handle(UpdatePackageServiceCommand request, CancellationToken cancellationToken)
    {
        var package = await _packageRepository.FindByAsync(
     expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Package Have Id {request.Id} Is Not Found");
        request.Adapt(package);
        await _packageRepository.UpdateAsync(package);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
