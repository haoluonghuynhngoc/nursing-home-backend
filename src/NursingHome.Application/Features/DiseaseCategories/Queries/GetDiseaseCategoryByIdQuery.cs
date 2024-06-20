using MediatR;
using NursingHome.Application.Features.DiseaseCategories.Models;

namespace NursingHome.Application.Features.DiseaseCategories.Queries;
public sealed record GetDiseaseCategoryByIdQuery(int Id) : IRequest<DiseaseCategoryResponse>;

