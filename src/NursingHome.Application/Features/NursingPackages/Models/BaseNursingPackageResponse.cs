﻿using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.NursingPackages.Models;
public record BaseNursingPackageResponse : BaseAuditableEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public StateType State { get; set; }
    public NursingPackageType Type { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public string? ImageUrl { get; set; }
    public int NumberOfNurses { get; set; }
    public int Capacity { get; set; }
}
