using Microsoft.Extensions.Logging;

namespace NursingHome.Application.TaskSchedulers.Impl;
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
