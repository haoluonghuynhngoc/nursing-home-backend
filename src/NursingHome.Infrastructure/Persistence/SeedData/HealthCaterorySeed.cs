using NursingHome.Domain.Entities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class HealthCaterorySeed
{
    public static List<HealthReportCategory> Default =>
         new List<HealthReportCategory>
         {
            new HealthReportCategory { Name = "Blood Sugar" },
            new HealthReportCategory { Name = "Cholesterol" },
            new HealthReportCategory { Name = "Lung" },
            new HealthReportCategory { Name = "Kidney" },
            new HealthReportCategory { Name = "Heart" },
         };
}
