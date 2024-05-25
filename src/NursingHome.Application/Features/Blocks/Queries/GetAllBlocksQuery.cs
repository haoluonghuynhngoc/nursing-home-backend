using MediatR;
using NursingHome.Application.Features.Blocks.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Blocks.Queries;
public sealed record GetAllBlocksQuery : IRequest<PaginatedResponse<BlockResponse>>
{
    /// <summary>
    /// Search field is search for  Name
    /// </summary>
    public string? Search { get; set; }

    public int? TotalFloor { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
