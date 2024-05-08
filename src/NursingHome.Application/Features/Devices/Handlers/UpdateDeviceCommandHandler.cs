using Mapster;
using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Devices.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Devices.Handlers;
internal sealed class UpdateDeviceCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<UpdateDeviceCommand, MessageResponse>
{
    private readonly IGenericRepository<Device> _deviceRepository = unitOfWork.Repository<Device>();
    public async Task<MessageResponse> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();

        var device = await _deviceRepository
            .FindByAsync(
            x => x.Id == request.Id &&
                 x.UserId == userId,
            cancellationToken: cancellationToken);

        if (device == null)
        {
            throw new NotFoundException(nameof(Device), request.Id);
        }

        var isConflict = await _deviceRepository
            .ExistsByAsync(x =>
                x.Id != request.Id &&
                x.UserId == userId &&
                x.Token == request.Token,
            cancellationToken: cancellationToken);

        if (isConflict)
        {
            throw new ConflictException(Resource.DeviceTokenConflict);
        }

        request.Adapt(device);

        await unitOfWork.CommitAsync(cancellationToken);

        return new MessageResponse(Resource.DeviceUpdatedSuccess);
    }
}
