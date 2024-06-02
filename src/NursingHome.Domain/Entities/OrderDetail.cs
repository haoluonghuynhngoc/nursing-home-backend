namespace NursingHome.Domain.Entities;
public class OrderDetail
{
    public long Id { get; set; }
    // thiếu kiểu dữ liệu lưu trữ CustomerId 
    // Ngày khách hàng đặt dịch vụ
    public string? Currency { get; set; }
    public decimal UnitPrice { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
    public Guid PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;

}