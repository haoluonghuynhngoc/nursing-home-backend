namespace NursingHome.Application.Features.PackageRegisterTypes.Models;
public sealed record PackageRegisterTypeResponse
{
    public int Id { get; set; }
    public string? NameRegister { get; set; }
    public PackageRegisterTypePackage Package { get; set; } = default!;
}

