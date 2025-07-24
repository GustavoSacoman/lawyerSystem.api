using lawyerSystem.api.Core.Dtos;
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

    public async Task<Lawyer> GetLawyerByOab(string OAB)
    {
        return await _database.Lawyers.FirstOrDefaultAsync(Lawyer => Lawyer.OABNumber == OAB)
            ?? throw new KeyNotFoundException("Lawyer not found");
    }

    public async Task UpdateLawyerAsync(Lawyer Lawyer)
    {
        _database.Update(Lawyer);
    }

    public async Task<IEnumerable<LawyerSummaryDto>> GetAllLawyersAsync(){

        return await _database.Lawyers.Select(
            lawyer => new LawyerSummaryDto(
                lawyer.UserId,
                lawyer.User.Name,
                lawyer.OABNumber,
                lawyer.Position.ToString())).ToListAsync();
    }
}
