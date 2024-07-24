using MediatR;
using NursingHome.Application.Features.MonthlyCalendarDetails.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.EmployeeTypes.Commands;
public record AddMonthlyCalendarDetailCommand : IRequest<MessageResponse>
{
    public EmployeeTypeName Name { get; set; }
    public ICollection<CreateMonthlyCalendarDetailsRequest> MonthlyCalendarDetails { get; set; } = new List<CreateMonthlyCalendarDetailsRequest>();
}

