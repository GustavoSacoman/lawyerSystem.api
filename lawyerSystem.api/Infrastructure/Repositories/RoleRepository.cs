using lawyerSystem.api.Core.Interfaces;
using lawyerSystem.api.Domain.Models;
using lawyerSystem.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace lawyerSystem.api.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    public readonly AppDbContext _database;

    public RoleRepository(AppDbContext database)
    {
        _database = database;
    }

    public async Task AddAsync(Role role)
    {
        await _database.Roles.AddAsync(role);
    }

    public async Task DeleteRoleAsync(Guid Id)
    {
        await _database.Roles
            .Where(r => r.Id == Id)
            .ExecuteDeleteAsync();
    }

    public async Task<Role> GetRoleAsync(Guid Id)
    {
        return await _database.Roles.FindAsync(Id) ?? throw new KeyNotFoundException("Role not found");
    }

    public async Task<Role> GetRoleByName(string name)
    {
        return await _database.Roles.FirstOrDefaultAsync(_database => _database.Name == name)
               ?? throw new KeyNotFoundException("Role not found");
    }

    public async Task UpdateRoleAsync(Role role)
    {
        _database.Update(role);
    }
}
