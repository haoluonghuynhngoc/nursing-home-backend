namespace NursingHome.Application.Features.Statistical.Models;
public record TotalUserResponse
{
    public int TotalUser { get; init; }
    public int TotalCustomer { get; init; }
    public int TotalDirector { get; init; }
    public int TotalManager { get; init; }
    public int TotalStaff { get; init; }
    public int TotalNurse { get; init; }
}
