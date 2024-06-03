using MediatR;
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
    private readonly IGenericRepository<PackageCategory> _packageTypeRepository = unitOfWork.Repository<PackageCategory>();
    private readonly IGenericRepository<PackageRegisterType> _packageRegisterTypeRepository = unitOfWork.Repository<PackageRegisterType>();
    public async Task<MessageResponse> Handle(CreatePackageRegisterCommand request, CancellationToken cancellationToken)
    {
        var packageCategory = await _packageTypeRepository.FindByAsync(_ => _.Name == PackageCategoryName.RegisterPackage)
            ?? throw new NotFoundException($"Package Type Have Name {PackageCategoryName.RegisterPackage} Is Not Found");

        var package = new Package
        {
            Name = request.Name,
            Description = request.Description,
            ImagePackage = request.ImagePackage,
            Color = request.Color,
            Price = request.Price,
            LimitedRegistration = request.LimitedRegistration,
            CurrentRegistrants = 0,
            NumberBed = request.NumberBed,
            Promotion = request.Promotion,
            Status = PackageStatusEnum.Active,
            //EffectiveDate = request.EffectiveDate,
            //ExpiryDate = request.ExpiryDate,
            Currency = request.Currency,
            //DurationMonth = UtilitiesExtensions.GetMonthsDifference(request.EffectiveDate, request.ExpiryDate),
            PackageCategory = packageCategory
        };
        if (request.PackageRegisterTypeId != null)
        {
            package.PackageRegisterType = await _packageRegisterTypeRepository.FindByAsync(_ => _.Id == request.PackageRegisterTypeId)
                ?? throw new NotFoundException($"Package Register Type Have Id {request.PackageRegisterTypeId} Is Not Found");
        }
        await _packageRepository.CreateAsync(package);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
