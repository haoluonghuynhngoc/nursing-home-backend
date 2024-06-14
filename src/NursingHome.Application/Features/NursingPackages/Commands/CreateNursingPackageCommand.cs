using MediatR;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.NursingPackages.Commands;
public record CreateNursingPackageCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public NursingPackageType Type { get; set; } = default!;
    public decimal Price { get; set; }
    public int RegistrationLimit { get; set; }
    public string? ImageUrl { get; set; }
    public int Capacity { get; set; }
}
