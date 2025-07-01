using lawyerSystem.api.Core.Interfaces;
using lawyerSystem.api.Domain.Models;
using lawyerSystem.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace lawyerSystem.api.Infrastructure.Repositories;

public class LawyerProfileRepository : ILawyerProfileRepositoyry
{
    public readonly AppDbContext _database;

    public LawyerProfileRepository(AppDbContext database)
    {
        _database = database;
    }

    public async Task AddAsync(Lawyer Lawyer)
    {
        await _database.Lawyers.AddAsync(Lawyer);
    }

    public async Task DeleteLawyerAsync(Guid Id)
    {
        await _database.Lawyers
            .Where(l => l.Id == Id)
            .ExecuteDeleteAsync();
    }

    public async Task<Lawyer> GetLawyerAsync(Guid Id)
    {
        return await _database.Lawyers.FindAsync(Id) ?? throw new KeyNotFoundException("Lawyer not found");
    }

    public async Task UpdateLawyerAsync(Lawyer Lawyer)
    {
        _database.Update(Lawyer);
    }

}
