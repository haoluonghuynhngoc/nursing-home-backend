using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Jobs;

namespace NursingHome.Infrastructure.Jobs;
public class TaskSchedulerOrder : ITaskSchedulerOrder
{
    private readonly ILogger<TaskSchedulerOrder> logger;

    public TaskSchedulerOrder(ILogger<TaskSchedulerOrder> logger)
    {
        this.logger = logger;
    }

    public void PrintNow()
    {
        logger.LogInformation($"Order Test: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}");
    }
    public void PrintTimeNow()
    {
        logger.LogInformation($"Time Test: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}");
    }
}