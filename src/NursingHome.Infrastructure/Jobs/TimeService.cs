using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Jobs;

namespace NursingHome.Infrastructure.Jobs;
public class TimeService : ITimeService
{
    private readonly ILogger<TimeService> logger;

    public TimeService(ILogger<TimeService> logger)
    {
        this.logger = logger;
    }

    public void PrintTimeNow()
    {
        logger.LogInformation($"Time Test: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}");
    }

}
