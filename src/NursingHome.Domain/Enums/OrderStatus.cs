namespace NursingHome.Domain.Enums;
public enum OrderStatus
{
    UnPaid, // đơn hàng mới tạo chưa thanh toán
    Failed, // đơn hàng thanh toán nhưng thất bại => thanh toán lại
    Paid, // đơn hàng đã thanh toán
    OverDue, // đơn hàng quá hạn thanh toán => hủy đơn hàng
    Cancelled, // đơn hàng bị hủy
}
