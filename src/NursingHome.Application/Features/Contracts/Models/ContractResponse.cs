using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.Contracts.Models;
public sealed record ContractResponse
{
    public Guid Id { get; set; }
    public string? NameCustomer { get; set; }
    public string? CCCD { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime SigningDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Content { get; set; }
    public string? ReasonForCanceling { get; set; }
    public string? ImageContract { get; set; }
    public ContractStatus? Status { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public ContractElder Elder { get; set; } = default!;
    public ContractCustomer User { get; set; } = default!;
}
