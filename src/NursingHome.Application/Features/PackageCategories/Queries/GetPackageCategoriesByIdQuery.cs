using MediatR;
using NursingHome.Application.Features.PackageCategories.Models;

namespace NursingHome.Application.Features.PackageCategories.Queries;
public sealed record GetPackageCategoriesByIdQuery(int Id) : IRequest<PackageCategoryResponse>;
