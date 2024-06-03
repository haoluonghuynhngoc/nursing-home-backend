using MediatR;
using NursingHome.Application.Features.Records.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Records.Queries;
public sealed record GetAllRecordQuery : IRequest<PaginatedResponse<RecordResponse>>
{
    public string? Search { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
