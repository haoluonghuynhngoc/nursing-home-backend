using EntityFrameworkCore.Projectables;
using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.NurseSchedules.Models;
using NursingHome.Application.Features.Orders.Models;
using NursingHome.Application.Features.Roles.Models;
using NursingHome.Domain.Enums;
using System.Text.Json.Serialization;

namespace NursingHome.Application.Features.Users.Models;
public record UserResponse : BaseUserResponse
{
    public ICollection<BaseNurseScheduleNoNurseResponse> NurseSchedules { get; set; } = new HashSet<BaseNurseScheduleNoNurseResponse>();
    public ICollection<RoleResponse> Roles { get; set; } = new HashSet<RoleResponse>();
    public ICollection<ElderRoomResponse> Elders { get; set; } = new HashSet<ElderRoomResponse>();
    public ICollection<BaseContractResponse> Contracts { get; set; } = new HashSet<BaseContractResponse>();
    [JsonIgnore]
    public ICollection<BaseOrderResponse> Orders { get; set; } = new List<BaseOrderResponse>();
    [Projectable]
    public ICollection<BaseOrderResponse> UnpaidOrders => Orders.Where(o => o.Status == OrderStatus.UnPaid).ToList();
}
