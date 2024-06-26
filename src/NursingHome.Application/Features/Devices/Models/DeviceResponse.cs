﻿using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Devices.Models;
public sealed record DeviceResponse
{
    public int Id { get; set; }
    public string Token { get; set; } = default!;

    [JsonIgnore]
    public Guid UserId { get; set; }
}
