using MediatR;
using NursingHome.Application.Features.PackageServicesTypes.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageServicesTypes.Queries;
public sealed record GetAllPackageServiceTypeQuery : IRequest<PaginatedResponse<PackageServiceTypeResponse>>
{
    /// <summary>
    /// Search field is search for  Name
    /// </summary>
    public string? Search { get; set; }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}