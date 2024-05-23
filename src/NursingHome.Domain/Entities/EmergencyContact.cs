namespace NursingHome.Domain.Entities;
internal class EmergencyContact
{
    // Liên hệ khẩn cấp
    // chưa cần sài 
    public int Id { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}
