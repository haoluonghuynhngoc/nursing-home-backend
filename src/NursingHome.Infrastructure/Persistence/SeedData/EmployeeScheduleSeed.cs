using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class EmployeeScheduleSeed
{
    public static List<int> monthInNV1 = new List<int> { 1, 2, 4, 5, 7, 8, 10, 11, 13, 14, 16, 17, 19, 20, 22, 23, 25, 26, 28, 29, 31 };
    public static List<int> monthInNV2 = new List<int> { 1, 3, 4, 6, 7, 9, 10, 12, 13, 15, 16, 18, 19, 21, 22, 24, 25, 27, 28, 30, 31 };
    public static List<int> monthInNV3 = new List<int> { 2, 3, 5, 6, 8, 9, 11, 12, 14, 15, 17, 18, 20, 21, 23, 24, 26, 27, 29, 30 };

    public static List<MonthlyCalendar> DefaultMonthlyCalendar =>
        Enumerable.Range(1, 31).Select(date => new MonthlyCalendar
        {
            DateInMonth = date
        }).ToList();

    public static List<EmployeeType> Default =>
        new List<EmployeeType>
        {
            new EmployeeType {
                Name = EmployeeTypeName.NV1
               // MonthlyCalendarDetails = GenerateMonthlyCalendarDetails(monthInNV1)
            },
            new EmployeeType {
                Name = EmployeeTypeName.NV2
                //MonthlyCalendarDetails = GenerateMonthlyCalendarDetails(monthInNV2)
            },
            new EmployeeType {
                Name = EmployeeTypeName.NV3
                //MonthlyCalendarDetails = GenerateMonthlyCalendarDetails(monthInNV3)
            },
        };

}
