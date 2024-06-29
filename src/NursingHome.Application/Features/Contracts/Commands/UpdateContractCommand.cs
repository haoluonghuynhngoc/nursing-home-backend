using MediatR;
using NursingHome.Application.Features.Images.Models;
using NursingHome.Application.Models;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Contracts.Commands;
public sealed record UpdateContractCommand : IRequest<MessageResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public DateOnly SigningDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public decimal Price { get; set; }
    public string? Content { get; set; } = default!;
    //public string ImageUrl { get; set; } = default!;
    public ICollection<CreateImageRequest> Images { get; set; } = new HashSet<CreateImageRequest>();
    public string? Notes { get; set; }
    public string? Description { get; set; }
}
