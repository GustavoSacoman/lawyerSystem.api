using lawyerSystem.api.Core.Dtos.Role;
namespace lawyerSystem.api.Core.Interfaces;

public interface IRoleService
{
    public Task<RoleDto> CreateRoleAsync(CreateRoleCommand roleCommand);

    public Task<IEnumerable<RoleDto>> GetAllRolesAsync();

    public Task<RoleDto> GetRoleByName(string Name);

    public Task<RoleDto> GetRoleByIdAsync(Guid Id);

    public Task UpdateRole(Guid Id,UpdateRoleCommand roleCommand);


}
