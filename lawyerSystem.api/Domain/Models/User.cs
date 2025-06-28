using lawyerSystem.api.Domain.Enums;

namespace lawyerSystem.api.Domain.Models;

public class User
{
    public required Guid Id { get; set; }

    public required string Name { get; set; } = string.Empty;

    public required string Email { get; set; } = string.Empty;

    public required string Phone { get; set; } = string.Empty;

    public required string Password { get; set; } = string.Empty;

    public required string Salt { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

}
