namespace NursingHome.Domain.Entities;
public class OrderDate
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
}
