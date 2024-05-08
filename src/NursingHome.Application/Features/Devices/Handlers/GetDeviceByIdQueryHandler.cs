using MediatR;
using NursingHome.Application.Common.Exceptions;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Devices.Models;
using NursingHome.Application.Features.Devices.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Devices.Handlers;
internal sealed class GetDeviceByIdQueryHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<GetDeviceByIdQuery, DeviceResponse>
{
    private readonly IGenericRepository<Device> _deviceRepository = unitOfWork.Repository<Device>();
    public async Task<DeviceResponse> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();

        var device = await _deviceRepository
            .FindByAsync<DeviceResponse>(
            x => x.Id == request.Id &&
                 x.UserId == userId,
            cancellationToken);

        if (device == null)
        {
            throw new NotFoundException(nameof(Device), request.Id);
        }

        return device;
    }
}
