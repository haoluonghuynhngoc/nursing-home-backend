using MediatR;
using NursingHome.Application.Features.Blocks.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Blocks.Queries;
public sealed record GetAllBlocksQuery : IRequest<PaginatedResponse<BlockResponse>>
{
    public string? Search { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

