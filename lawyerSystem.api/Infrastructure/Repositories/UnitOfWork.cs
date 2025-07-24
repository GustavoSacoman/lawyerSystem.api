using lawyerSystem.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace lawyerSystem.api.Infrastructure.Repositories;

public class UnitOfWork
{
    public readonly AppDbContext _database;

    public IUserProfileRepository Users { get; }

    public ILawyerProfileRepository Lawyers { get; }

    public IRoleRepository Roles { get; }

    public UnitOfWork(AppDbContext database)
    {
        _database = database;
        Users = new UserProfileRepository(_database);
        Lawyers = new LawyerProfileRepository(_database);
        Roles = new RoleRepository(_database);

    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _database.Dispose();
        GC.SuppressFinalize(this);
    }
}
