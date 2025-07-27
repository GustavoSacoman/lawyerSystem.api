using lawyerSystem.api.Core.Interfaces;
using lawyerSystem.api.Core.Services;
using lawyerSystem.api.Infrastructure.Data;
using lawyerSystem.api.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace lawyerSystem.api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string 'DefaultConnection' is not configured.");
        }

        services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));

        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
        //services.AddScoped<IUserRepository, UserRepository>();

        //services.AddScoped<IUserRoleRepository, UserRoleRepository>();
    }
}
