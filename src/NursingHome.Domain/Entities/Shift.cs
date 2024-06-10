namespace NursingHome.Domain.Entities;
public class Shift
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;
    public virtual ICollection<NurseScheduler> NurseSchedulers { get; set; } = new HashSet<NurseScheduler>();
}
