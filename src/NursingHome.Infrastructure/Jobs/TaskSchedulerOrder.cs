using Microsoft.Extensions.Logging;
using NursingHome.Application.Contracts.Jobs;
using NursingHome.Application.Contracts.Repositories;
using NursingHome.Domain.Entities;
using NursingHome.Domain.Enums;

namespace NursingHome.Infrastructure.Jobs;
public class TaskSchedulerOrder : ITaskSchedulerOrder
{
    private readonly ILogger<TaskSchedulerOrder> logger;
    private readonly IGenericRepository<Contract> _contractRepository;
    private readonly IGenericRepository<Order> _orderRepository;
    public TaskSchedulerOrder(IUnitOfWork unitOfWork, ILogger<TaskSchedulerOrder> logger)
    {
        _contractRepository = unitOfWork.Repository<Contract>();
        _orderRepository = unitOfWork.Repository<Order>();
        this.logger = logger;
    }

    public async void CheckContractExpirationAsync()
    {
        var currentDate = DateOnly.FromDateTime(DateTime.Now);

        var listContracts = await _contractRepository.FindAsync();
        foreach (var contract in listContracts)
        {
            if (contract.StartDate == currentDate)
            {
                contract.Status = ContractStatus.Valid;
                // gửi mail thông báo hợp đồng đã được kích hoạt
            }
            if (contract.StartDate < currentDate && contract.EndDate > currentDate)
            {
                // thực hiện 1 vài cái gì đó 
            }
            var notificationDate = contract.EndDate;
            if (notificationDate.AddDays(-3) == currentDate)
            {
                // gửi email thông báo sắp hết hạn
            }
            if (contract.EndDate == currentDate)
            {
                contract.Status = ContractStatus.Expired;
                // gửi email thông báo hợp đồng đã hết hạn
            }
        }
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