using MediatR;
using NursingHome.Application.Features.HealthCategories.Models;

namespace NursingHome.Application.Features.HealthCategories.Queries;
public sealed record GetHealthCategoryByIdQuery(int Id) : IRequest<HealthCategoryResponse>;