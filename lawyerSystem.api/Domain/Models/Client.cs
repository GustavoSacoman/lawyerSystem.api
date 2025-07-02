using lawyerSystem.api.Domain.Enums.Client;

namespace lawyerSystem.api.Domain.Models;

public class Client
{
    required public Guid Id { get; set; }

    required public ClientType ClientType { get; set; }

    required public bool isActive { get; set; } = true;

    required public string CPF { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? CNPJ { get; set; }

    public string? CompanyName { get; set; }

    public string? TradingName { get; set; }

    required public Guid UserId { get; set; }

    required public virtual User User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
