using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Blocks.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Blocks.Queries;
public sealed record GetAllBlocksQuery : PaginationRequest<Block>, IRequest<PaginatedResponse<BlockResponse>>
{
    public string? Search { get; set; }

    public override Expression<Func<Block, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(_.Name, $"%{Search}%"));

        return Expression;
    }
}

