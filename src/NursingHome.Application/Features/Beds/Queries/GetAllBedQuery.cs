using MediatR;
using NursingHome.Application.Features.Beds.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Beds.Queries;
public sealed record GetAllBedQuery : IRequest<PaginatedResponse<BedResponse>>
{
    /// <summary>
    /// Search field is search for  Status  "In use", "Available", "Under maintenance"
    /// </summary>
    public string? Search { get; set; }
    /// <summary>
    /// Search By Room Id
    /// </summary>
    public int? RoomId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
