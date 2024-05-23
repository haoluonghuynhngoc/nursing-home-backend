namespace NursingHome.Domain.Entities;
public class BillDetail
{
    public long Id { get; set; }
    public string? Currency { get; set; }
    public decimal UnitPrice { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
    public Guid BillId { get; set; }
    public virtual Bill Bill { get; set; } = default!;
    public Guid PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;

}
