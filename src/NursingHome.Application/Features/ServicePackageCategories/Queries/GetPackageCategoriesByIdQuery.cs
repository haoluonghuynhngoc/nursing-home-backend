using MediatR;
using NursingHome.Application.Features.ServicePackageCategories.Models;

namespace NursingHome.Application.Features.PackageCategories.Queries;
public sealed record GetPackageCategoriesByIdQuery(int Id) : IRequest<PackageCategoryResponse>;
