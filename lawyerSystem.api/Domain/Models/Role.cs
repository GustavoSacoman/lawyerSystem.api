using lawyerSystem.api.Core.Interfaces;

namespace lawyerSystem.api.Domain.Models;

public class Role : IAuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    required public string Name { get; set; } = string.Empty;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
