using lawyerSystem.api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lawyerSystem.api.Infrastructure.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(r => r.Name)
            .IsUnique();

        var seedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        builder.HasData(
            new Role
            {
                Id = Guid.Parse("1632a2f1-1f82-4d8f-a6a5-b6fd12f4dd04"),
                Name = "Admin",
                CreatedAt = seedDate,
                UpdatedAt = seedDate,
            },
            new Role
            {
                Id = Guid.Parse("b8dabe03-dfd4-4f6e-99b8-9131e0d0d1e2"),
                Name = "Lawyer",
                CreatedAt = seedDate,
                UpdatedAt = seedDate,
            },
            new Role
            {
                Id = Guid.Parse("42e53229-3e64-4ab7-8758-ce25b155612a"),
                Name = "Client",
                CreatedAt = seedDate,
                UpdatedAt = seedDate,
            }
            );

        builder.Property(r => r.CreatedAt)
            .HasConversion(
                v => v,
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        builder.Property(r => r.UpdatedAt)
            .HasConversion(
                v => v,
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
    }
}
