namespace NursingHome.Domain.Enums;
public enum ContractStatus
{
    //InUse,
    //Cancelled,
    //Expired,
    Pending, // đã gia hạn nhưng chưa sử dụng hợp đồng  pending, valist, invalist, cancel
    Valid,
    Invalid,
    Cancelled
}
