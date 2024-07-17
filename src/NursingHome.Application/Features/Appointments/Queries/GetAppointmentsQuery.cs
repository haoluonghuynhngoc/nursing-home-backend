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
    public int? ContractId { get; set; }

    public override Expression<Func<Appointment, bool>> GetExpressions()
    {
        Expression = Expression.And(_ => string.IsNullOrWhiteSpace(Search) || EF.Functions.Like(_.Name, $"%{Search}%"))
            .And(_ => !UserId.HasValue || _.UserId == UserId)
            .And(_ => !Date.HasValue || _.Date == Date)
            .And(_ => !Type.HasValue || _.Type == Type)
            .And(_ => !Status.HasValue || _.Status == Status)
            .And(_ => !ContractId.HasValue || _.ContractId == ContractId)
            .And(_ => !NursingPackageId.HasValue || _.NursingPackageId == NursingPackageId);

        return Expression;
    }
}
