using Mapster;
using MediatR;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Devices.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Devices.Handlers;
internal sealed class CreateDeviceCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<CreateDeviceCommand, MessageResponse>
{
    private readonly IGenericRepository<Device> _deviceRepository = unitOfWork.Repository<Device>();
    public async Task<MessageResponse> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();

        var isConflict = await _deviceRepository
            .ExistsByAsync(x =>
                x.UserId == userId &&
                x.Token == request.Token,
            cancellationToken: cancellationToken);

        if (isConflict)
        {
            //throw new ConflictException(Resource.DeviceTokenAlreadyRegistered);
            return new MessageResponse(Resource.DeviceCreatedSuccess);
        }

        var device = request.Adapt<Device>();
        device.UserId = userId;

        await _deviceRepository.CreateAsync(device, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeviceCreatedSuccess);
    }
}
