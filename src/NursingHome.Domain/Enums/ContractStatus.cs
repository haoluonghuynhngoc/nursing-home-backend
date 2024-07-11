namespace NursingHome.Domain.Enums;
public enum ContractStatus
{
    //InUse,
    //Cancelled,

    Pending, // đã gia hạn nhưng chưa sử dụng hợp đồng  pending, valist, invalist, cancel
    Valid,
    //Invalid,
    Expired,
    Cancelled
}
