using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.DiseaseCategories.Commands;
public sealed record CreateDiseaseCategoryCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    [JsonIgnore]
    public StateType State => StateType.Active;
}
