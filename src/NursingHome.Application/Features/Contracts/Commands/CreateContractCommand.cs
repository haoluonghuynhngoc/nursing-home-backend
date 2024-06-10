using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Contracts.Commands;
public sealed record CreateContractCommand : IRequest<MessageResponse>
{
    public int ElderId { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = default!;
    public DateTime SigningDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Content { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string? Notes { get; set; }
    public string? Description { get; set; }
}
