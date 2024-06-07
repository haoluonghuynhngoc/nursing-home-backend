using MediatR;
using NursingHome.Application.Models;

namespace NursingHome.Application.Features.Blocks.Commands;
public sealed record CreateBlockCommand : IRequest<MessageResponse>
{
    public string Name { get; set; } = default!;
    public int TotalRoom { get; set; }
}
