using lawyerSystem.api.Domain.Interfaces;

namespace lawyerSystem.api.Domain.Models;

public class UserRole : IAuditableEntity
{
    public required Guid UserId { get; set; }

    public virtual User User { get; set; }

    public required Guid RoleId { get; set; }

    public virtual Role Role { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
