namespace lawyerSystem.api.Core.Dtos;

public record UserDto(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    DateTime CreatedAt,
    ICollection<RoleDto> Roles, // Uma lista dos papéis do usuário
    LawyerDto? LawyerProfile,   // O perfil de advogado (pode ser nulo)
    ClientDto? ClientProfile    // O perfil de cliente (pode ser nulo)
);

