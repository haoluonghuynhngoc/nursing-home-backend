using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Elders.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Elders.Handlers;
internal sealed class CreateElderCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<CreateElderCommand, MessageResponse>
{
    private readonly IGenericRepository<Elder> _elderRepository = unitOfWork.Repository<Elder>();
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    private readonly IGenericRepository<User> _userRepository = unitOfWork.Repository<User>();
    private readonly IGenericRepository<PackageType> _packageTypeRepository = unitOfWork.Repository<PackageType>();
    public async Task<MessageResponse> Handle(CreateElderCommand request, CancellationToken cancellationToken)
    {
        var packageRegister = await _packageRepository.FindByAsync(_ => _.Id == request.PackageRegisterId)
             ?? throw new NotFoundException($"Package Register Have Id {request.PackageRegisterId} Is Not Found");
        var guardian = await _userRepository.FindByAsync(_ => _.Id == request.UserCustomerId)
             ?? throw new NotFoundException($"User Customer Have Id {request.UserCustomerId} Is Not Found");
        var packageType = await _packageTypeRepository.FindByAsync(_ => _.Id == packageRegister.PackageTypeId)
             ?? throw new NotFoundException($"Package Type Have Id {packageRegister.PackageTypeId} Is Not Found");

        if (packageType.Name != PackageTypeName.RegisterPackage)
        {
            throw new BadRequestException(Resource.PackageRegisterIsNotAvailable);
        }
        var elder = new Elder
        {
            FullName = request.FullName,
            IdentityNumber = request.IdentityNumber,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            ImageUrl = request.ImageUrl,
            Address = request.Address,
            Nationality = request.Nationality,
            Status = request.Status,
            EffectiveDate = request.EffectiveDate,
            ExpiryDate = request.ExpiryDate,
            Price = packageRegister.Price,
            Notes = request.Notes,
            InDate = request.InDate,
            OutDate = request.OutDate,
            ElderUsers = new HashSet<ElderUser>
            {
               new() {
                   User = guardian
               }
            },
            ElderPackageRegisters = new HashSet<ElderPackageRegister>
            {
                new()
                {
                    NamePackage = PackageTypeName.RegisterPackage.ToString(),
                    Package = packageRegister,
                   // EffectiveDate = request.UserPackageDay,
                   // ExpiryDate = request.UserPackageDay.AddMonths(packageRegster.DurationMonth),
                   // Status = request.UserPackageDay <= DateTime.Now ? "Hasn't Started Yet" : "Started"
                }
            }
        };
        await _elderRepository.CreateAsync(elder);
        await unitOfWork.CommitAsync();
        return new MessageResponse(Resource.CreatedSuccess);
    }
}
