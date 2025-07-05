using lawyerSystem.api.Domain.Enums.Lawyer;

namespace lawyerSystem.api.Core.Dtos;

public record UpdateLawyerDto
{
    public string? OABNumber { get; init; }

    public string? OABState { get; init; }

    public Position? Position { get; init; }

    public string? Biography { get; init; }

}