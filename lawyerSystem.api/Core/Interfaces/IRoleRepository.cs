using lawyerSystem.api.Domain.Models;

namespace lawyerSystem.api.Core.Interfaces;

public interface IRoleRepository
{
    /// <summary>
    /// Adds a new role to the repository.
    /// </summary>
    /// <param name="role">The role to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(Role role);

    public Task<Role> GetRoleByIdAsync(Guid Id);

    public Task<IEnumerable<Role>> GetAllRolesAsync();
    public Task<Role> GetRoleByName(string name);
    public Task UpdateRoleAsync(Role role);

    public Task DeleteRoleAsync(Guid Id);
}
