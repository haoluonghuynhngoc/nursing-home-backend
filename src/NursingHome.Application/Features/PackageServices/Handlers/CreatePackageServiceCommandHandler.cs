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
    private readonly IGenericRepository<PackageServiceType> _packageServicesTypesRepository = unitOfWork.Repository<PackageServiceType>();
    public async Task<MessageResponse> Handle(CreatePackageServiceCommand request, CancellationToken cancellationToken)
    {
        var packageType = await _packageTypeRepository.FindByAsync(_ => _.Name == PackageTypeName.ServicePackage)
             ?? throw new NotFoundException($"Package Type Have Name {PackageTypeName.ServicePackage} Is Not Found");
        var listPackageServiceType = new HashSet<PackageServiceType>();

        foreach (var item in request.PackageServiceTypes)
        {
            listPackageServiceType.Add(await _packageServicesTypesRepository.FindByAsync(_ => _.Id == item)
             ?? throw new NotFoundException($"Package Service Type Have Id {item} Is Not Found"));
        }

        var serviceBooking = new ServiceBooking();

        switch (request.RepeatPatternTypes)
        {
            case RepeatPatternType.OneTime:
                serviceBooking.RepeatType = RepeatPatternType.OneTime;
                serviceBooking.MaxCapacity = request.SubscriberLimit ?? 0;
                serviceBooking.CurrentCapacity = 0;
                serviceBooking.status = ResourceStatus.Active;
                serviceBooking.Calendars = new HashSet<Calendar>() {
                new Calendar(){
                    EventDate = request.EventDate,
                }};
                break;
            case RepeatPatternType.Daily:
                serviceBooking.RepeatType = RepeatPatternType.Daily;
                serviceBooking.status = ResourceStatus.Active;
                serviceBooking.Calendars = new HashSet<Calendar>() {
                new Calendar(){
                    EventDate = request.EventDate,
                }};
                break;
            case RepeatPatternType.Weekly:
                serviceBooking.RepeatType = RepeatPatternType.Daily;
                serviceBooking.status = ResourceStatus.Active;
                serviceBooking.Calendars = new HashSet<Calendar>();
                if (request.DayOfWeeks != null)
                {
                    foreach (var item in request.DayOfWeeks)
                    {
                        serviceBooking.Calendars.Add(new Calendar()
                        {
                            DayOfWeek = item
                        });
                    }
                }
                break;
            default:
                serviceBooking.RepeatType = RepeatPatternType.Unlimited;
                serviceBooking.status = ResourceStatus.Active;
                break;
        }

        var package = new Package
        {
            Name = request.Name,
            Description = request.Description,
            ImagePackage = request.ImagePackage,
            Color = request.Color,
            Price = request.Price,
            Currency = request.Currency,
            DurationTime = request.DurationTime,
            PackageServiceTypes = listPackageServiceType,
            PackageType = packageType,
            ServiceBooking = serviceBooking
        };

        await _packageRepository.CreateAsync(package);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
