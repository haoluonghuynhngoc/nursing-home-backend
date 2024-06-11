﻿using NursingHome.Domain.Common;

namespace NursingHome.Domain.Entities;
public class PackageDate : BaseEntity<int>
{
    public DateTime Date { get; set; }
    public int PackageId { get; set; }
    public virtual Package Package { get; set; } = default!;
}
