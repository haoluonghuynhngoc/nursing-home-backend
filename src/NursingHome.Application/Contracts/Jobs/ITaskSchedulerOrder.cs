namespace NursingHome.Application.Contracts.Jobs;
public interface ITaskSchedulerOrder
{
    public void PrintNow();
    void PrintTimeNow();
    //public void CheckContractExpirationAsync();
    public Task CreateDisplayRenewalNotificationAsync();
    public Task CheckContractExpirationAsync();
    public Task CheckOrderDetailExpirationAsync();
}
