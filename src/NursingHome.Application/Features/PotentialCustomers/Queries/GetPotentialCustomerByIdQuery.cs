using MediatR;
using NursingHome.Application.Features.PotentialCustomers.Models;

namespace NursingHome.Application.Features.PotentialCustomers.Queries;
public record GetPotentialCustomerByIdQuery(int Id) : IRequest<PotentialCustomerResponse>;
