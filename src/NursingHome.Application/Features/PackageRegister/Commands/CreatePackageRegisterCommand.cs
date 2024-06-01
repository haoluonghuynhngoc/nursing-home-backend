﻿using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.PackageRegister.Commands;
public sealed record CreatePackageRegisterCommand : IRequest<MessageResponse>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public int NumberBed { get; set; }
    // public DateTime EffectiveDate { get; set; }
    //public DateTime ExpiryDate { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public string? Currency { get; set; }
    //[JsonIgnore]
    //public int DurationMonth { get; set; }
}