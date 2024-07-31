using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.NursingPackages.Commands;
public record UpdateNursingPackageCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public NursingPackageType Type { get; set; } = default!;
    public int NumberOfNurses { get; set; }
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public string? ImageUrl { get; set; }
    public int Capacity { get; set; }
}
