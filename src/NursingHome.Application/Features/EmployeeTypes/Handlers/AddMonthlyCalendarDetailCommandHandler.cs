using MediatR;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Application.Features.EmployeeTypes.Commands;
using NursingHome.Application.Models;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.EmployeeTypes.Handlers;
internal class AddMonthlyCalendarDetailCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<AddMonthlyCalendarDetailCommand, MessageResponse>
{
    private readonly IGenericRepository<MonthlyCalendarDetail> _monthlyCalendarDetailRepository = unitOfWork.Repository<MonthlyCalendarDetail>();
    private readonly IGenericRepository<Shift> _shiftRepository = unitOfWork.Repository<Shift>();
    private readonly IGenericRepository<MonthlyCalendar> _monthlyCalendarRepository = unitOfWork.Repository<MonthlyCalendar>();
    private readonly IGenericRepository<EmployeeType> _employeeTypeRepository = unitOfWork.Repository<EmployeeType>();
    public async Task<MessageResponse> Handle(AddMonthlyCalendarDetailCommand request, CancellationToken cancellationToken)
    {
        var employeeTypes = await _employeeTypeRepository.FindAsync(_ => _.Name == request.Name, isAsNoTracking: false);
        // var listShift = await _shiftRepository.FindAsync(isAsNoTracking: false);

        foreach (var detail in request.MonthlyCalendarDetails)
        {
            var listShift = await _shiftRepository.FindAsync(isAsNoTracking: false);
            var monthlyCalendars = await _monthlyCalendarRepository.FindAsync(_ =>
            detail.DateInMonth.Contains(_.DateInMonth), isAsNoTracking: false);

            if (detail.ShiftNames == ShiftType.Morning)
            {
                listShift = listShift.Where(_ => _.Name == ShiftName.Morning || _.Name == ShiftName.Afternoon).ToList();
            }
            else
            {
                listShift = listShift.Where(_ => _.Name == ShiftName.Noon || _.Name == ShiftName.Evening).ToList();
            }
            foreach (var iteamEmployeeTypes in employeeTypes)
            {
                foreach (var iteamMonthlyCalendars in monthlyCalendars)
                {
                    iteamEmployeeTypes.MonthlyCalendarDetails.Add(CreateMonthlyCalendarDetail(iteamMonthlyCalendars, listShift));
                    await _employeeTypeRepository.UpdateAsync(iteamEmployeeTypes);
                }
            }
        }
        await unitOfWork.CommitAsync(cancellationToken);
        return new MessageResponse(Resource.UpdatedSuccess);
    }

    private MonthlyCalendarDetail CreateMonthlyCalendarDetail(MonthlyCalendar monthlyCalendar, ICollection<Shift> shiftNames)
    {

        return new MonthlyCalendarDetail
        {
            Shifts = shiftNames,
            MonthlyCalendar = monthlyCalendar,
        };
    }
}