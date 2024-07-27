using MediatR;
using NursingHome.Application.Features.ScheduledServices.Models;

namespace NursingHome.Application.Features.ScheduledServices.Queries;
public sealed record GetScheduledServiceByIdQuery(int Id) : IRequest<ScheduledServiceResponse>;
