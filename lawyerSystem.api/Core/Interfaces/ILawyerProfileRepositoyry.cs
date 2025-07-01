using lawyerSystem.api.Domain.Models;

namespace lawyerSystem.api.Core.Interfaces;

public interface ILawyerProfileRepositoyry
{
    public Task AddAsync(Lawyer lawyer);

    public Task<Lawyer> GetLawyerAsync(Guid Id);

    public Task UpdateLawyerAsync(Lawyer Lawyer);

    public Task DeleteLawyerAsync(Guid Id);
}
