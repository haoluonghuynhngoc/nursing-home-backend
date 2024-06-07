using MediatR;
using NursingHome.Application.Features.Blocks.Models;

namespace NursingHome.Application.Features.Blocks.Queries;
public sealed record GetBlockByIdQuery(Guid Id) : IRequest<BlockResponse>;

