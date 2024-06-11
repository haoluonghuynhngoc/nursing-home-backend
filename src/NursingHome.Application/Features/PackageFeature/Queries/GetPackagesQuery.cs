﻿using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.PackageFeature.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.PackageFeature.Queries;
public record GetPackagesQuery : PaginationRequest<Package>, IRequest<PaginatedResponse<PackageResponse>>
{
    public string? Search { get; set; }

    public PackageType? Type { get; set; }
    public int? PackageCategoryId { get; set; }

    public Guid? UserId { get; set; }

    public override Expression<Func<Package, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(_.Name, $"%{Search}%"));
        Expression = Expression.And(_ => !Type.HasValue || _.Type == Type);
        Expression = Expression.And(_ => !PackageCategoryId.HasValue || _.PackageCategoryId == PackageCategoryId);
        Expression = Expression.And(_ => !UserId.HasValue || _.Orders.Any(_ => _.UserId == UserId));
        return Expression;
    }
}