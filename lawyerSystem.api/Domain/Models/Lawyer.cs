using lawyerSystem.api.Domain.Enums.Lawyer;

namespace lawyerSystem.api.Domain.Models;

public class Lawyer
{
    public required Guid Id { get; set; } 

    public required string OABNumber { get; set; } = string.Empty;

    public required string OABState { get; set; } = string.Empty; 

    public required Position Position { get; set; }

    public required bool IsActive { get; set; } = true;

    public string? Biography { get; set; } 

    public Guid UserId { get; set; }
    public virtual required User User { get; set; }
}
