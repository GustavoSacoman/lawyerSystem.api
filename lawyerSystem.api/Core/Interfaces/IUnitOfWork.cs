namespace lawyerSystem.api.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserProfileRepository Users { get; }

    ILawyerProfileRepositoyry Lawyers { get; }

    IRoleRepository Roles { get; }

    Task<int> SaveChangesAsync();
}
