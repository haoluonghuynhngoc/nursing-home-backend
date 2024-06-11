using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.PackageFeature.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageFeature.Handlers;
internal class UpdatePackageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdatePackageCommand, MessageResponse>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    public async Task<MessageResponse> Handle(UpdatePackageCommand request, CancellationToken cancellationToken)
    {
        var package = await _packageRepository
            .FindByAsync(
                x => x.Id == request.Id,
                _ => _.Include(_ => _.PackageDates),
            cancellationToken: cancellationToken);

        if (package is null)
        {
            throw new NotFoundException(nameof(Package), request.Id);
        }

        request.Adapt(package);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
