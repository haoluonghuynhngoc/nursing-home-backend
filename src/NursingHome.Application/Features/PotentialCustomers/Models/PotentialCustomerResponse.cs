using NursingHome.Application.Features.Users.Models;

namespace NursingHome.Application.Features.PotentialCustomers.Models;
public record PotentialCustomerResponse : BasePotentialCustomerResponse
{
    public ICollection<BaseUserResponse> Users { get; set; } = new HashSet<BaseUserResponse>();
}
