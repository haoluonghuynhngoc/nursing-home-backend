using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Blocks.Commands;
public sealed record CreateBlockCommand : IRequest<MessageResponse>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public int TotalFloor { get; set; }
}

