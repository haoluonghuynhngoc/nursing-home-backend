using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.PotentialCustomers.Models;
public record PotentialCustomerResponse : BasePotentialCustomerResponse
{
    public BaseUserResponse User { get; set; } = default!;
}
