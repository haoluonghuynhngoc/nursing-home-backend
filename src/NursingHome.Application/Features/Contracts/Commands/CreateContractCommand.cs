using MediatR;
using NursingHome.Application.Features.Images.Models;
using NursingHome.Application.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Contracts.Commands;
public sealed record CreateContractCommand : IRequest<MessageResponse>
{
    public int NursingPackageId { get; set; }
    public int ElderId { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = default!;
    public DateOnly SigningDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public decimal Price { get; set; }
    public string? Notes { get; set; }
    public string? Description { get; set; }
    [JsonIgnore]
    public ContractStatus Status { get; set; } = default!;
    public string? Content { get; set; } = default!;
    //public string ImageUrl { get; set; } = default!;
    public ICollection<CreateImageRequest> Images { get; set; } = new HashSet<CreateImageRequest>();

}
