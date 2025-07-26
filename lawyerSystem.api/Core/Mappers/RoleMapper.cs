using AutoMapper;
using lawyerSystem.api.Core.Dtos.Role;
using lawyerSystem.api.Domain.Models;

namespace lawyerSystem.api.Core.Mappers;

public class RoleMapper : Profile
{
    public RoleMapper()
    {
        CreateMap<Role, RoleDto>();

        CreateMap<CreateRoleCommand, Role>();
    }
}
