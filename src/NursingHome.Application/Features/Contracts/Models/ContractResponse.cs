namespace NursingHome.Application.Features.Contracts.Models;
public sealed record ContractResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime SigningDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? ReasonForCanceling { get; set; }
    public string Content { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string? Notes { get; set; }
    public string Status { get; set; } = default!;
    public string? Description { get; set; }
    public int ElderId { get; set; }
    public int UserId { get; set; }

}
