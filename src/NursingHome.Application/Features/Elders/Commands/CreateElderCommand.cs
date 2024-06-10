﻿using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Elders.Commands;
public sealed record CreateElderCommand : IRequest<MessageResponse>
{
    public int RoomId { get; set; }
    public Guid UserId { get; set; }
    public int NursingPackageId { get; set; }
    public string Name { get; set; } = default!;
    public string DateOfBirth { get; set; } = default!;
    public GenderStatus Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? Address { get; set; }
    public string? Nationality { get; set; }
    [JsonIgnore]
    public ElderStatus Status { get; set; }
    public string? Notes { get; set; }

}
