﻿using NursingHome.Application.Features.PackageFeature.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PackageCategories.Models;
public sealed record PackageCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public PackageCategoryType Type { get; set; }
    public ICollection<PackageResponse> Packages { get; set; } = new HashSet<PackageResponse>();
}
