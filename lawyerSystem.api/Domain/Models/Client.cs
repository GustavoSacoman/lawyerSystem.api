namespace lawyerSystem.api.Domain.Models;

public class Client
{
    public Guid Id { get; set; }

    public ClientType ClientType { get; set; } 

    public required bool isActive { get; set; } = true;

    public required string CPF { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? CNPJ { get; set; }

    public string? CompanyName { get; set; }

    public string? TradingName { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
