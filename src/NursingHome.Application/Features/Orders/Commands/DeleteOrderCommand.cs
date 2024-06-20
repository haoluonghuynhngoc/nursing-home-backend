using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Orders.Commands;
public record DeleteOrderCommand(int Id) : IRequest<MessageResponse>;