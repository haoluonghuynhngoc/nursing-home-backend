﻿using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PackageRegister.Commands;
public sealed record CreatePackageRegisterCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int? PackageRegisterTypeId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePackage { get; set; }
    public int NumberBed { get; set; }
    public int LimitedRegistration { get; set; }
    public string? Promotion { get; set; }
    // public DateTime EffectiveDate { get; set; }
    //public DateTime ExpiryDate { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }
    public string? Currency { get; set; }
    //[JsonIgnore]
    //public int DurationMonth { get; set; }
}
