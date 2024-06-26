﻿using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;

namespace NursingHome.Domain.Entities;
public class Device : BaseEntity<int>
{
    public string Token { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
}
