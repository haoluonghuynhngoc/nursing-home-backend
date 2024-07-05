namespace NursingHome.Domain.Enums;
public enum OrderDetailStatus
{

    NonRepeatable,  // Gói dịch vụ không thể lặp lại
    Repeatable,    // Gói dịch vụ có thể lặp lại
    Finalized,    // Gói dịch vụ đã hoàn tất 
}
