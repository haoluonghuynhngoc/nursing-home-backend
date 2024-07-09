using NursingHome.Application.Models;
using NursingHome.Domain.Enums;

namespace NursingHome.Application.Features.PotentialCustomers.Models;
public record BasePotentialCustomerResponse : BaseAuditableEntityResponse<int>
{
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public PotentialCustomerStatus Status { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }

}
