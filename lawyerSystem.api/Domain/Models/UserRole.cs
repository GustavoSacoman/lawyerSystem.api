namespace lawyerSystem.api.Domain.Models;

public class UserRole
{
    public required Guid UserId { get; set; }

    public virtual User User { get; set; }

    public required Guid RoleId { get; set; }

    public virtual Role Role { get; set; }

}
