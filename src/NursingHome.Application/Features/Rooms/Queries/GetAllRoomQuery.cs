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
    public int? NursingPackageId { get; set; }
    // true là phòng đã được lên lịch chăm sóc
    // false là phòng chưa được lên lịch chăm sóc
    public bool? IsScheduled { get; set; }
    public RoomType? Type { get; set; }
    public int? CareMonth { get; set; }
    public int? CareYear { get; set; }
    /// <summary>
    /// AvailableBed true là phòng còn giường có thể cho thêm người vào 
    /// </summary>
    public bool? AvailableBed { get; set; }
    public override Expression<Func<Room, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"));
        }
        Expression = Expression
            .And(r => !Type.HasValue || r.Type == Type)
            .And(r => !NursingPackageId.HasValue || r.NursingPackageId == NursingPackageId)
            .And(r => !AvailableBed.HasValue || r.AvailableBed == AvailableBed)
            .And(r => !IsScheduled.HasValue || r.CareSchedules.Any(_ => (!CareMonth.HasValue || _.CareMonth == CareMonth)
            && (!CareYear.HasValue || _.CareYear == CareYear)) == IsScheduled);
        return Expression;
    }

}