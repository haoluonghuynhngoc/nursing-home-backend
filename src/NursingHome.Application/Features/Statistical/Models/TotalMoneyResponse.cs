namespace NursingHome.Application.Features.Statistical.Models;
public record TotalMoneyResponse
{
    public double TotalMoney { get; init; }
    public double TotalMoneyNursingPackage { get; init; }
    public double TotalMoneyServicePackage { get; init; }
}
