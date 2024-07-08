using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.PotentialCustomers.Commands;
public record DeletePotentialCustomerCommand(int Id) : IRequest<MessageResponse>;
