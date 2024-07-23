using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.HealthCategories.Commands;
public sealed record UpdateStateHealthCategoryCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public StateType State { get; set; }
}
