using MediatR;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Shared.Pages;

namespace NursingHome.Application.Features.Rooms.Queries;
public sealed record GetAllRoomCommand : IRequest<PaginatedResponse<RoomResponse>>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public string? Search { get; init; }

}