﻿namespace NursingHome.Application.Features.Beds.Models;
public sealed record BedElderResponse
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? IdentityNumber { get; set; }
    public string? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public string? Status { get; set; }
    public string? Notes { get; set; }
    public DateTime InDate { get; set; }
    public DateTime OutDate { get; set; }
}