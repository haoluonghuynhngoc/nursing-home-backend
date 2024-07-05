namespace NursingHome.Domain.Enums;
public enum OrderDetailType
{
    // Thêm field thì nhớ check ở CreateOrderServicePackageCommandHandler
    One_Time,
    RecurringDay,
    RecurringWeeks
}
