﻿using NursingHome.Application.Features.PackageCategories.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageFeature.Models;
public record PackageResponse : BaseEntityResponse<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public int TimeBetweenServices { get; set; }
    public string? ImageUrl { get; set; }
    public int Capacity { get; set; }
    public PackageType Type { get; set; } = default!;
    public int PackageCategoryId { get; set; }
    public virtual PackageCategoryResponse PackageCategory { get; set; } = default!;
    public virtual ICollection<PackageDateResponse> PackageDates { get; set; } = new HashSet<PackageDateResponse>();
}