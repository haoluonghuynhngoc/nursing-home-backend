using MediatR;
using NursingHome.Application.Features.OrderDates.Models;

namespace NursingHome.Application.Features.OrderDates.Queries;
public record GetOrderDateByIdQuery(int Id) : IRequest<OrderDateResponse>;
