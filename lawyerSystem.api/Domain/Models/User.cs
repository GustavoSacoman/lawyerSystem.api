using lawyerSystem.api.Core.Interfaces;
using lawyerSystem.api.Domain.Enums;

namespace lawyerSystem.api.Domain.Models;

public class User : IAuditableEntity
{
    required public Guid Id { get; set; }

    required public string Name { get; set; } = string.Empty;

    required public string Email { get; set; } = string.Empty;

    required public string Phone { get; set; } = string.Empty;

    required public string PasswordHash { get; set; } = string.Empty;

    required public string Salt { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

}
