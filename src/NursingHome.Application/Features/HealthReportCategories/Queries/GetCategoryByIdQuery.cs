using MediatR;
using NursingHome.Application.Features.HealthReportCategories.Models;

namespace NursingHome.Application.Features.HealthReportCategories.Queries;
public sealed record GetCategoryByIdQuery(int Id) : IRequest<ReportCategoryResponse>;
