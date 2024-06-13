using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Contracts.Models;
public sealed record ContractResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public DateOnly SigningDate { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string? Content { get; set; } = default!;
    public string? ImageUrl { get; set; }
    public string? Notes { get; set; }
    public string? ReasonForCanceling { get; set; }
    public ContractStatus Status { get; set; } = default!;
    public string? Description { get; set; }
    public int ElderId { get; set; }
    public Guid UserId { get; set; }

}
