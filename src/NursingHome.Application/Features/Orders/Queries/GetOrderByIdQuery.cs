using MediatR;
using NursingHome.Application.Features.Orders.Models;

namespace NursingHome.Application.Features.Orders.Queries;
public record GetOrderByIdQuery(int Id) : IRequest<OrderResponse>;