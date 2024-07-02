using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class ShiftSeed
{
    public static List<Shift> Default =>
        new List<Shift>
        {
            new Shift {
               Name = ShiftName.Morning,
               StartTime = new TimeOnly(7, 30),
               EndTime = new TimeOnly(11, 30)
            },
            new Shift {
              Name = ShiftName.Noon,
               StartTime = new TimeOnly(12, 0),
               EndTime = new TimeOnly(16, 0)
            },
            new Shift {
               Name = ShiftName.Afternoon,
               StartTime = new TimeOnly(17, 0),
               EndTime = new TimeOnly(0, 0)
            },
            new Shift {
               Name = ShiftName.Evening,
               StartTime = new TimeOnly(0, 0),
               EndTime = new TimeOnly(7, 0)
            },
        };
}
