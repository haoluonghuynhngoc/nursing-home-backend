namespace NursingHome.Domain.Entities;
public class PackageDate
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;
}
