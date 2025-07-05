namespace lawyerSystem.api.Core.Interfaces;

public interface IAuditableEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
