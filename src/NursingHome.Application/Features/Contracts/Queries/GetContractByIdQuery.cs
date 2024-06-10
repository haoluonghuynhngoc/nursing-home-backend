using MediatR;
using NursingHome.Application.Features.Contracts.Models;

namespace NursingHome.Application.Features.Contracts.Queries;
public sealed record GetContractByIdQuery(int Id) : IRequest<ContractResponse>;
