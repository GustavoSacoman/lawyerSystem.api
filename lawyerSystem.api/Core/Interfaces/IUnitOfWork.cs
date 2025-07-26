namespace lawyerSystem.api.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRoleRepository Roles { get; }

    Task<int> SaveChangesAsync();
}
