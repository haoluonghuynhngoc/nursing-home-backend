using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NursingHome.Application.Features.Appointments.Models;
using NursingHome.Application.Models.Pages;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;
using NursingHome.Shared.Pages;
using System.Linq.Expressions;

namespace NursingHome.Application.Features.Appointments.Queries;
public record GetAppointmentsQuery : PaginationRequest<Appointment>, IRequest<PaginatedResponse<AppointmentResponse>>
{
    public string? Search { get; set; }
    public DateOnly? Date { get; set; }
    public Guid? UserId { get; set; }
    public AppointmentType? Type { get; set; }
    public AppointmentStatus? Status { get; set; }
    public int? NursingPackageId { get; set; }
    public override Expression<Func<Appointment, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(_.Name, $"%{Search}%"));
        Expression = Expression.And(_ => !UserId.HasValue || _.UserId == UserId);
        Expression = Expression.And(_ => !Date.HasValue || _.Date == Date);
        Expression = Expression.And(_ => !Type.HasValue || _.Type == Type);
        Expression = Expression.And(_ => !Status.HasValue || _.Status == Status);
        Expression = Expression.And(_ => !NursingPackageId.HasValue || !_.NursingPackageId.HasValue || _.NursingPackageId == NursingPackageId);
        return Expression;
    }
}
