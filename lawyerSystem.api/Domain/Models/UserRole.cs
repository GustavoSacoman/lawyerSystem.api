﻿using lawyerSystem.api.Core.Interfaces;

namespace lawyerSystem.api.Domain.Models;

public class UserRole : IAuditableEntity
{
    public Guid UserId { get; set; }

    public virtual User User { get; set; }

    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}
