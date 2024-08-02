namespace NursingHome.Application.Contracts.Jobs;
public interface ITaskSchedulerOrder
{
    //public void CheckContractExpirationAsync();
    public Task CheckAppointmentExpirationAsync();
    public Task CreateDisplayRenewalNotificationAsync();
    public Task CheckContractExpirationAsync();
    public Task CheckOrderDetailExpirationAsync();
    public Task CheckOrderExpirationAsync();
    public Task CheckOrderRepeatableAsync();
}
