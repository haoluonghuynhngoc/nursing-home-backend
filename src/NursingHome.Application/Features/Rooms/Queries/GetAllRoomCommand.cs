﻿using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Rooms.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Rooms.Queries;
public sealed record GetAllRoomCommand : PaginationRequest<Room>, IRequest<PaginatedResponse<RoomResponse>>
{
    /// <summary>
    /// Search field is search for name, status
    /// </summary>
    public string? Search { get; set; }
    public TypeEnum? Type { get; set; }
    public bool? AvailableBed { get; set; }
    public override Expression<Func<Room, bool>> GetExpressions()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Search = Search.Trim();
            Expression = Expression
                .And(u => EF.Functions.Like(u.Name, $"%{Search}%"))
                .Or(u => EF.Functions.Like(u.Status, $"%{Search}%"));
        }
        return Expression;
    }

}