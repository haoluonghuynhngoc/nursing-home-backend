using MediatR;
using NursingHome.Application.Features.PackageTypes.Models;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageTypes.Queries;
public sealed record GetAllPackageTypeQuery : IRequest<PaginatedResponse<PackageTypeResponse>>
{
    /// <summary>
    /// Search field is search for  Name
    /// </summary>
    public PackageTypeName? Search { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
