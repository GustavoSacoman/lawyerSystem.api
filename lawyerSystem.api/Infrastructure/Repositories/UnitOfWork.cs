using lawyerSystem.api.Core.Interfaces;
using lawyerSystem.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace lawyerSystem.api.Infrastructure.Repositories;

public class UnitOfWork
{
    public readonly AppDbContext _database;

    public IRoleRepository Roles { get; }

    public UnitOfWork(AppDbContext database)
    {
        _database = database;
        Roles = new RoleRepository(_database);

    }

    public Task<int> SaveChangesAsync()
    {
        return _database.SaveChangesAsync();
    }

    public void Dispose()
    {
        _database.Dispose();
        GC.SuppressFinalize(this);
    }
}
