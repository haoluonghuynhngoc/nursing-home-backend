﻿using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Rooms.Models;
public sealed record RoomElderResponse
{
    public string? FullName { get; set; }
    public string? IdentityNumber { get; set; }
    public string? DateOfBirth { get; set; }
    public GenderStatus Gender { get; set; } = GenderStatus.Male;
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    public ElderStatus Status { get; set; }
    public string? Notes { get; set; }
    public DateTime InDate { get; set; }
    public DateTime OutDate { get; set; }
}
