namespace NursingHome.Application.Features.PackageServicesTypes.Models;
public sealed record PackageServiceTypePackage
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public string? Content { get; set; }
    public string? Status { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public string? Currency { get; set; }
    public int DurationTime { get; set; }
}
