using MediatR;
using NursingHome.Application.Features.CareSchedules.Models;

namespace NursingHome.Application.Features.CareSchedules.Queries;
public sealed record GetCareScheduleByIdQuery(int Id) : IRequest<CareScheduleResponse>;
