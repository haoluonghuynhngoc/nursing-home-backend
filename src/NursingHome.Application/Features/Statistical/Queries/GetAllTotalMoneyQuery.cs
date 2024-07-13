using MediatR;
using NursingHome.Application.Features.Statistical.Models;

namespace NursingHome.Application.Features.Statistical.Queries;
public sealed record GetAllTotalMoneyQuery : IRequest<TotalMoneyResponse>;
