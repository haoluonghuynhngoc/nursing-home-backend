using MediatR;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Contracts.Services;
using NursingHome.Application.Features.Devices.Models;
using NursingHome.Application.Features.Devices.Queries;
using NursingHome.Domain.Entities;

namespace NursingHome.Application.Features.Devices.Handlers;
internal sealed class GetDevicesQueryHandler(
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : IRequestHandler<GetDevicesQuery, IList<DeviceResponse>>
{
    private readonly IGenericRepository<Device> _deviceRepository = unitOfWork.Repository<Device>();

    public async Task<IList<DeviceResponse>> Handle(GetDevicesQuery request, CancellationToken cancellationToken)
    {
        var userId = await currentUserService.FindCurrentUserIdAsync();

        return await _deviceRepository.FindAsync<DeviceResponse>(
            _ => _.UserId == userId,
            cancellationToken: cancellationToken);
    }
}
