namespace lawyerSystem.api.Core.Dtos;

public record ClientDto(
    Guid Id,
    string ClientType,
    string? CPF,
    string? isActive,
    DateTime? DateOfBirth,
    string? CNPJ,
    string? CompanyName,
    string? TradingName);
