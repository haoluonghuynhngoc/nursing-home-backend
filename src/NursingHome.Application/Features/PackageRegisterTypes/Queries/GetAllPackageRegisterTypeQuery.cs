using MediatR;
using NursingHome.Application.Features.PackageRegisterTypes.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageRegisterTypes.Queries;
public sealed record GetAllPackageRegisterTypeQuery : IRequest<PaginatedResponse<PackageRegisterTypeResponse>>
{
    public string? Search { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
