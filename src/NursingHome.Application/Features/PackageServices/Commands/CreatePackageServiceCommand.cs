using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.PackageServices.Commands;
public sealed record CreatePackageServiceCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public List<int> PackageServiceTypes { get; set; } = new();
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? ImagePackage { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }
    public string? Currency { get; set; }
    public int DurationTime { get; set; }

    [JsonIgnore]
    public RepeatPatternType RepeatPatternTypes { get; set; }
    public DateTime? EventDate { get; set; }
    public int? SubscriberLimit { get; set; }
    public int? DailyRepeat { get; set; }
    public List<DayOfWeekEnum>? DayOfWeeks { get; set; }
}
