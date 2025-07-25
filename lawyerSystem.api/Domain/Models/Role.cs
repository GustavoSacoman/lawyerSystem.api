using lawyerSystem.api.Domain.Interfaces;

namespace lawyerSystem.api.Domain.Models;

public class Role : IAuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; } = string.Empty;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
