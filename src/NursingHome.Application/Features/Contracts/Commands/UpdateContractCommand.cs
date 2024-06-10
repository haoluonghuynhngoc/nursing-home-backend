using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Contracts.Commands;
public sealed record UpdateContractCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime SigningDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Content { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string? Notes { get; set; }
    public string? Description { get; set; }
}
