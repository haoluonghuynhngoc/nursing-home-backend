namespace NursingHome.Application.Features.Statistical.Models;
public record TotalUserResponse
{
    public int TotalUser { get; set; }
    public int TotalCustomer { get; set; }
    public int TotalDirector { get; set; }
    public int TotalManager { get; set; }
    public int TotalStaff { get; set; }
    public int TotalNurse { get; set; }
}
