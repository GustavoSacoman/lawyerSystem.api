using Microsoft.EntityFrameworkCore;

namespace lawyerSystem.api.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    // Define DbSets for your entities here, e.g.:
    // public DbSet<User> Users { get; set; }
    // public DbSet<Role> Roles { get; set; }
    // public DbSet<UserRole> UserRoles { get; set; }

}