using FluentValidation;
using FluentValidation.AspNetCore;
using lawyerSystem.api.Core.Interfaces;
using lawyerSystem.api.Core.Services;
using lawyerSystem.api.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace lawyerSystem.api.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRoleService, RoleService>();
        //services.AddScoped(IUserService, UserService);

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        return services;
    }
}
