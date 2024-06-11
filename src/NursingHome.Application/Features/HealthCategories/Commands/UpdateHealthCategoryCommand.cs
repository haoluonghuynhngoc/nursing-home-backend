using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.HealthCategories.Commands;
public sealed record UpdateHealthCategoryCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? ImageUrl { get; set; } = default!;
    public string? Description { get; set; }
}
