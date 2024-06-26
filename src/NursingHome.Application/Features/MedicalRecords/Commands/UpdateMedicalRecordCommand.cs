﻿using MediatR;
using NursingHome.Application.Features.DiseaseCategories.Models;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.MedicalRecords.Commands;
public record UpdateMedicalRecordCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }

    public string? BloodType { get; set; }
    public string? Weight { get; set; }
    public string? Move { get; set; }
    public string? Height { get; set; }
    public string? UnderlyingDisease { get; set; }
    public string? Note { get; set; }
    public virtual ICollection<CreateDiseaseCategoriesRequest> DiseaseCategories { get; set; } = new HashSet<CreateDiseaseCategoriesRequest>();
}
