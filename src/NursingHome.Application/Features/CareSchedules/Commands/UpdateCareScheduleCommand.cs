﻿using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.CareSchedules.Commands;
public sealed record UpdateCareScheduleCommand : IRequest<MessageResponse>
{
}