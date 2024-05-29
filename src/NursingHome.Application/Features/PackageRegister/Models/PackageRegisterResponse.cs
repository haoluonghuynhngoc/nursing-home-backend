﻿namespace NursingHome.Application.Features.PackageRegister.Models;
public sealed record PackageRegisterResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public string? Status { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public int Capacity { get; set; }
    public string? Currency { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int DurationTime { get; set; }
    public int DurationMonth { get; set; }
}
