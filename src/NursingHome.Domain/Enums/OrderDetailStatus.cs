namespace NursingHome.Domain.Enums;
public enum OrderDetailStatus
{
    Repeatable,    // Gói dịch vụ có thể lặp lại
    NonRepeatable,  // Gói dịch vụ không thể lặp lại
    Finalized,    // Gói dịch vụ đã hoàn tất 
}
