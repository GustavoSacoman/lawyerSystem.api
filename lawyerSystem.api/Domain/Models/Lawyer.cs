using lawyerSystem.api.Domain.Enums.Lawyer;

namespace lawyerSystem.api.Domain.Models;

public class Lawyer
{
    required public Guid Id { get; set; }

    required public string OABNumber { get; set; } = string.Empty;

    required public string OABState { get; set; } = string.Empty;

    required public Position Position { get; set; }

    required public bool IsActive { get; set; } = true;

    public string? Biography { get; set; }

    required public Guid UserId { get; set; }

    required public virtual User User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
