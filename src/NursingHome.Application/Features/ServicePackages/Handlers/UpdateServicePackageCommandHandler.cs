﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.ServicePackages.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.ServicePackages.Handlers;
internal class UpdateServicePackageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateServicePackageCommand, MessageResponse>
{
    private readonly IGenericRepository<ServicePackage> _servicePackageRepository = unitOfWork.Repository<ServicePackage>();

    public async Task<MessageResponse> Handle(UpdateServicePackageCommand request, CancellationToken cancellationToken)
    {
        var package = await _servicePackageRepository
            .FindByAsync(
                x => x.Id == request.Id,
                _ => _.Include(_ => _.ServicePackageDates),
            cancellationToken: cancellationToken);

        if (package is null)
        {
            throw new NotFoundException(nameof(ServicePackage), request.Id);
        }

        request.Adapt(package);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
