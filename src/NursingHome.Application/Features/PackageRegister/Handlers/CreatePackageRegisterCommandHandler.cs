﻿using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.PackageRegister.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageRegister.Handlers;
internal sealed class CreatePackageRegisterCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<CreatePackageRegisterCommand, MessageResponse>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    private readonly IGenericRepository<PackageType> _packageTypeRepository = unitOfWork.Repository<PackageType>();
    public async Task<MessageResponse> Handle(CreatePackageRegisterCommand request, CancellationToken cancellationToken)
    {
        var packageType = await _packageTypeRepository.FindByAsync(_ => _.Name == PackageTypeName.RegisterPackage)
            ?? throw new NotFoundException($"Package Type Have Name {PackageTypeName.RegisterPackage} Is Not Found");

        var package = new Package
        {
            Name = request.Name,
            Description = request.Description,
            ImagePackage = request.ImagePackage,
            Color = request.Color,
            Price = request.Price,
            NumberBed = request.NumberBed,
            //EffectiveDate = request.EffectiveDate,
            //ExpiryDate = request.ExpiryDate,
            Currency = request.Currency,
            //DurationMonth = UtilitiesExtensions.GetMonthsDifference(request.EffectiveDate, request.ExpiryDate),
            PackageType = packageType

        };
        await _packageRepository.CreateAsync(package);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}