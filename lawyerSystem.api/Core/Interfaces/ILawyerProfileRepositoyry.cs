using lawyerSystem.api.Domain.Models;

namespace lawyerSystem.api.Core.Interfaces;

public interface ILawyerProfileRepositoyry
{
    public Task AddAsync(Lawyer Lawyer);

    public Task<Lawyer> GetLawyerAsync(Guid Id);

    public Task<Lawyer> GetLawyerByOab(string OAB);

    public Task UpdateLawyerAsync(Lawyer Lawyer);

    public Task DeleteLawyerAsync(Guid Id);

    public Task<IEnumerable<Lawyer>> GetAllLawyersAsync();
}
