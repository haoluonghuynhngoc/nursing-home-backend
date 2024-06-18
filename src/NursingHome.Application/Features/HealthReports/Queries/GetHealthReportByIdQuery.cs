using MediatR;
using NursingHome.Application.Features.HealthReports.Models;

namespace NursingHome.Application.Features.HealthReports.Queries;
public sealed record GetHealthReportByIdQuery(int Id) : IRequest<HealthReportResponse>;
