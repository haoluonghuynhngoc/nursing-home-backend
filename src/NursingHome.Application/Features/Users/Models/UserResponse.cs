﻿using NursingHome.Application.Features.Contracts.Models;
using NursingHome.Application.Features.Elders.Models;
using NursingHome.Application.Features.Roles.Models;

namespace NursingHome.Application.Features.Users.Models;
public record UserResponse : BaseUserResponse
{
    public ICollection<RoleResponse> Roles { get; set; } = new HashSet<RoleResponse>();
    public virtual ICollection<ElderRoomResponse> Elders { get; set; } = new HashSet<ElderRoomResponse>();
    public virtual ICollection<BaseContractResponse> Contracts { get; set; } = new HashSet<BaseContractResponse>();
}
