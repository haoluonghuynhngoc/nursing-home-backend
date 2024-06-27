using MediatR;
using NursingHome.Application.Features.Devices.Models;

namespace NursingHome.Application.Features.Devices.Queries;
public sealed record GetDevicesQuery : IRequest<IList<DeviceResponse>>;

