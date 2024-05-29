using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.PackageServices.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageServices.Handlers;
internal sealed class CreatePackageServiceCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<CreatePackageServiceCommand, MessageResponse>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    private readonly IGenericRepository<PackageType> _packageTypeRepository = unitOfWork.Repository<PackageType>();
    public async Task<MessageResponse> Handle(CreatePackageServiceCommand request, CancellationToken cancellationToken)
    {
        var packageType = await _packageTypeRepository.FindByAsync(_ => _.Name == PackageTypeName.ServicePackage)
             ?? throw new NotFoundException($"Package Type Have Name {PackageTypeName.ServicePackage} Is Not Found");

        var package = new Package
        {
            Name = request.Name,
            Description = request.Description,
            ImagePackage = request.ImagePackage,
            Status = request.Status,
            Color = request.Color,
            Price = request.Price,
            Currency = request.Currency,
            DurationTime = request.DurationTime,
            DurationMonth = request.DurationMonth,
            PackageType = packageType
        };
        await _packageRepository.CreateAsync(package);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
