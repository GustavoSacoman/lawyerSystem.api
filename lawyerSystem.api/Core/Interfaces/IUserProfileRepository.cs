using lawyerSystem.api.Domain.Models;

namespace lawyerSystem.api.Core.Interfaces;

public interface IUserProfileRepository
{
    public Task AddAsync(User user);

    public Task<User> GetUserAsync(Guid Id);

    public Task UpdateUserAsync(User user);

    public Task DeleteUserAsync(Guid Id);

    public Task<User> GetUserByEmail(string Email);
}
