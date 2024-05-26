using MediatR;
using NursingHome.Application.Features.HealthReportCategories.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.HealthReportCategories.Queries;
public sealed record GetAllCategoryQuery : IRequest<PaginatedResponse<ReportCategoryResponse>>
{
    /// <summary>
    /// Search field is search for  Name
    /// </summary>
    public string? Search { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}