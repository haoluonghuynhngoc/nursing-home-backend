using MediatR;
using NursingHome.Application.Features.Contracts.Models;

namespace NursingHome.Application.Features.Contracts.Queries;
public sealed record GetContractByIdQuery(Guid Id) : IRequest<ContractResponse>;
