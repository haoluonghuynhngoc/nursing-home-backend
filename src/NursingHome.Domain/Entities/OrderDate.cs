namespace NursingHome.Domain.Entities;
public class OrderDate
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
}
