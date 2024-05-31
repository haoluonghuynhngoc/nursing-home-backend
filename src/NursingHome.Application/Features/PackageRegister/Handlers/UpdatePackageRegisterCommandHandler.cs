using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.PackageRegister.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.PackageRegister.Handlers;
internal sealed class UpdatePackageRegisterCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<UpdatePackageRegisterCommand, MessageResponse>
{
    private readonly IGenericRepository<Package> _packageRepository = unitOfWork.Repository<Package>();
    // private readonly IGenericRepository<PackageType> _packageTypeRepository = unitOfWork.Repository<PackageType>();
    public async Task<MessageResponse> Handle(UpdatePackageRegisterCommand request, CancellationToken cancellationToken)
    {
        //   var packageType = await _packageTypeRepository.FindByAsync(_ => _.Id == request.)
        //?? throw new NotFoundException($"Package Type Have Name {PackageTypeName.Subscription} Is Not Found");

        var package = await _packageRepository.FindByAsync(
    expression: _ => _.Id == request.Id) ?? throw new NotFoundException($"Package Have Id {request.Id} Is Not Found");
        request.Adapt(package);
        //package.DurationMonth = UtilitiesExtensions.GetMonthsDifference(request.EffectiveDate, request.ExpiryDate);
        await _packageRepository.UpdateAsync(package);
        await unitOfWork.CommitAsync();

        return new MessageResponse(Resource.UpdatedSuccess);
    }
}
