namespace NursingHome.Application.Features.PackageRegister.Models;
public sealed record PackageRegisterBlock
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public int TotalFloor { get; set; }
}
