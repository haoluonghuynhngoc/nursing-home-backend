namespace NursingHome.Application.Features.Elders.Models;
public sealed record ElderNursingPackages
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string ImageUrl { get; set; } = default!;
    public decimal Price { get; set; }
    public int Capacity { get; set; }
}
