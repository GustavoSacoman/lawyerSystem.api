using lawyerSystem.api.Domain.Enums.Lawyer;

namespace lawyerSystem.api.Core.Dtos;

public record CreateLawyerCommand
{
    required public string Name { get; init; } = string.Empty;

    required public string Email { get; init; } = string.Empty;

    required public string Phone { get; init; } = string.Empty;

    required public string Password { get; init; } = string.Empty;

    required public string OABNumber { get; init; } = string.Empty;

    required public string OABState { get; init; } = string.Empty;

    required public Position Position { get; init; }

    public string? Biography { get; init; }
}