using lawyerSystem.api.Domain.Enums.Lawyer;

namespace lawyerSystem.api.Core.Dtos;

public record LawyerDto(
    Guid Id,
    string OABNumber,
    string OABState,
    string Position,
    bool isActive,
    string? Biography);