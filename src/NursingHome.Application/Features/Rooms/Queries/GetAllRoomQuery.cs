using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Rooms.Queries;
public sealed record GetAllRoomQuery : PaginationRequest<Room>, IRequest<PaginatedResponse<RoomResponse>>
{

    public string? Search { get; set; }
    public RoomType? Type { get; set; }
    public override Expression<Func<Room, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"));
        }
        Expression = Expression.Or(
            r => r.Type == Type);
        return Expression;
    }

}