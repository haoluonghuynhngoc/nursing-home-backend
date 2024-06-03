using MediatR;
using NursingHome.Application.Features.PackageCategories.Models;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.PackageCategories.Queries;
public sealed record GetAllPackageCategoryQuery : IRequest<PaginatedResponse<PackageCategoryResponse>>
{
    public PackageCategoryName? Search { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
