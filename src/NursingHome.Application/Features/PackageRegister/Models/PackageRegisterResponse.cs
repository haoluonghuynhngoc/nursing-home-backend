namespace NursingHome.Application.Features.PackageRegister.Models;
public sealed record PackageRegisterResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public string? Status { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public int NumberBed { get; set; }
    public string? Currency { get; set; }
    public ICollection<PackageRegisterRoom> Rooms { get; set; } = new HashSet<PackageRegisterRoom>();
}
