using MediatR;
using NursingHome.Application.Features.OrderDetails.Models;

namespace NursingHome.Application.Features.OrderDetails.Queries;
public sealed record GetOrderDetailByIdQuery(int Id) : IRequest<OrderDetailResponse>;
