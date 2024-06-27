﻿using MediatR;
using NursingHome.Application.Features.Devices.Models;

namespace NursingHome.Application.Features.Devices.Queries;
public sealed record GetDeviceByIdQuery(int Id) : IRequest<DeviceResponse>;
