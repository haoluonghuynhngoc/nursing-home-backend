using MediatR;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Blocks.Commands;
public sealed record UpdateBlockCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int TotalRoom { get; set; }
}
