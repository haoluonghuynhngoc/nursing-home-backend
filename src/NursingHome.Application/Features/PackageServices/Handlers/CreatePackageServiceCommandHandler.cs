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
    private readonly IGenericRepository<PackageCategory> _packageTypeRepository = unitOfWork.Repository<PackageCategory>();
    private readonly IGenericRepository<PackageServiceType> _packageServicesTypesRepository = unitOfWork.Repository<PackageServiceType>();
    public async Task<MessageResponse> Handle(CreatePackageServiceCommand request, CancellationToken cancellationToken)
    {
        var packageCategory = await _packageTypeRepository.FindByAsync(_ => _.Name == PackageCategoryName.ServicePackage)
             ?? throw new NotFoundException($"Package Type Have Name {PackageCategoryName.ServicePackage} Is Not Found");

        var listPackageServiceType = new HashSet<PackageServiceType>();
        foreach (var item in request.PackageServiceTypes)
        {
            listPackageServiceType.Add(await _packageServicesTypesRepository.FindByAsync(_ => _.Id == item)
             ?? throw new NotFoundException($"Package Service Type Have Id {item} Is Not Found"));
        }

        var calendar = new Calendar();

        switch (request.RepeatPatternTypes)
        {
            case RepeatPatternType.OneTime:
                calendar.RepeatType = RepeatPatternType.OneTime;
                calendar.status = ResourceStatus.Active;
                calendar.EventDate = request.EventDate;
                break;
            case RepeatPatternType.Daily:
                calendar.RepeatType = RepeatPatternType.Daily;
                calendar.status = ResourceStatus.Active;
                calendar.DateRepeat = request.DateRepeat;
                break;
            case RepeatPatternType.Weekly:
                calendar.RepeatType = RepeatPatternType.Weekly;
                calendar.status = ResourceStatus.Active;
                if (request.DayOfWeeks != null)
                {
                    calendar.DayOfWeekList = new List<DayOfWeekEnum>();
                    foreach (var item in request.DayOfWeeks)
                    {
                        calendar.DayOfWeekList?.Add(item);
                    }
                }

                break;
            default:
                calendar.RepeatType = RepeatPatternType.Unlimited;
                calendar.status = ResourceStatus.Active;
                break;
        }
        var package = new Package
        {
            Name = request.Name,
            Description = request.Description,
            ImagePackage = request.ImagePackage,
            LimitedRegistration = request.LimitedRegistration,
            CurrentRegistrants = 0,
            Color = request.Color,
            Price = request.Price,
            Status = PackageStatusEnum.Active,
            Currency = request.Currency,
            DurationTime = request.DurationTime,
            PackageServiceTypes = listPackageServiceType,
            PackageCategory = packageCategory,
            Calendar = calendar,
        };

        await _packageRepository.CreateAsync(package);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
