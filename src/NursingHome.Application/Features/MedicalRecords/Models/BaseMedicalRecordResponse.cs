﻿using NursingHome.Application.Features.DiseaseCategories.Models;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.MedicalRecords.Models;
public record BaseMedicalRecordResponse : BaseAuditableEntityResponse<int>
{
    public string? BloodType { get; set; }
    public string? Weight { get; set; }
    public string? Move { get; set; }
    public string? Height { get; set; }
    public string? UnderlyingDisease { get; set; }
    public string? Note { get; set; }
    public int ElderId { get; set; }
    public ICollection<BaseDiseaseCategoryResponse> DiseaseCategories { get; set; } = new HashSet<BaseDiseaseCategoryResponse>();
}
