using MediatR;
using NursingHome.Application.Features.PackageCategories.Models;

namespace NursingHome.Application.Features.PackageCategories.Queries;
public sealed record GetPackageCategoryByIdQuery(int Id) : IRequest<PackageCategoryResponse>;
