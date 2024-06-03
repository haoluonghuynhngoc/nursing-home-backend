using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageCategories.Models;
public sealed record PackageCategoryPackage
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public PackageStatusEnum Status { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public string? Content { get; set; }
    public int NumberBed { get; set; }
    public int LimitedRegistration { get; set; }
    public int CurrentRegistrants { get; set; }
    public string? Promotion { get; set; }
    public string? Currency { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int DurationTime { get; set; }
    public int DurationMonth { get; set; }
}
