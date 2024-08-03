using NursingHome.Application.Features.Images.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Contracts.Models;
public record CreateContractRequest
{
    public string Name { get; set; } = default!;
    public DateOnly SigningDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string? Content { get; set; } = default!;
    //public string? ImageUrl { get; set; } CreateImageRequest
    public string? Notes { get; set; }
    public ICollection<CreateImageRequest> Images { get; set; } = new HashSet<CreateImageRequest>();
    public string? Description { get; set; }
    [JsonIgnore]
    public ContractStatus Status { get; set; } = default!;

    public decimal Price { get; set; }
    [JsonIgnore]
    public Guid UserId { get; set; }
    [JsonIgnore]
    public int? NursingPackageId { get; set; }
}
