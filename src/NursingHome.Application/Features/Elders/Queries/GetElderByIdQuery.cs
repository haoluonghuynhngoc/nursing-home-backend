﻿using MediatR;
using NursingHome.Application.Features.Elders.Models;

namespace NursingHome.Application.Features.Elders.Queries;
public sealed record GetElderByIdQuery(Guid Id) : IRequest<ElderResponse>;