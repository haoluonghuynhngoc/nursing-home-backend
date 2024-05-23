namespace NursingHome.Domain.Entities;
public class CareScheduleTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public bool IsDone { get; set; }
    public long CareScheduleId { get; set; }
    public virtual CareSchedule CareSchedule { get; set; } = default!;
}
