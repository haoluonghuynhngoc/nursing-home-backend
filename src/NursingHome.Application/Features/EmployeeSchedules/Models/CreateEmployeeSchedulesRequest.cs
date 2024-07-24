namespace NursingHome.Application.Features.EmployeeSchedules.Models;
public record CreateEmployeeSchedulesRequest
{
    public Guid UserId { get; set; }
    public int EmployeeTypeId { get; set; }
}
