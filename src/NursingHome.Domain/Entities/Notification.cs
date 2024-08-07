﻿using EntityFrameworkCore.Projectables;
using NursingHome.Domain.Common;
using NursingHome.Domain.Entities.Identities;
using NursingHome.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NursingHome.Domain.Entities;
public class Notification : BaseAuditableEntity<int>
{
    public string? Title { get; set; }
    public string? Content { get; set; }

    [Projectable]
    public bool IsRead => ReadAt.HasValue;
    public DateTimeOffset? ReadAt { get; set; }

    [Column(TypeName = "nvarchar(24)")]
    public NotificationLevel Level { get; set; }
    public string? Data { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;

}