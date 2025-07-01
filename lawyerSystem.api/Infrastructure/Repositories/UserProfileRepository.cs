using lawyerSystem.api.Core.Interfaces;
using lawyerSystem.api.Domain.Models;
using lawyerSystem.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace lawyerSystem.api.Infrastructure.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
    public readonly AppDbContext _database;

    public UserProfileRepository(AppDbContext database)
    {
        _database = database;
    }

    public async Task AddAsync(User user)
    {
        await _database.Users.AddAsync(user);
    }

    public async Task DeleteUserAsync(Guid Id)
    {
        await _database.Users
            .Where(u => u.Id == Id)
            .ExecuteDeleteAsync();
    }

    public async Task<User> GetUserAsync(Guid Id)
    {
        return await _database.Users.FindAsync(Id) ?? throw new KeyNotFoundException("User not found");
    }

    public async Task<User> GetUserByEmail(string Email)
    {
        return await _database.Users.FirstOrDefaultAsync(user => user.Email == Email);
    }

    public async Task UpdateUserAsync(User user)
    {
       _database.Update(user);
    }
}
