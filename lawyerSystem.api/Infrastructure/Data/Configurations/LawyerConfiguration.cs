using lawyerSystem.api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lawyerSystem.api.Infrastructure.Data.Configurations;

public class LawyerConfiguration : IEntityTypeConfiguration<Lawyer>
{
    public void Configure(EntityTypeBuilder<Lawyer> builder)
    {
        builder.ToTable("Lawyers");

        builder.HasKey(l => l.Id);

        builder.HasOne(l => l.User)
               .WithOne()
               .HasForeignKey<Lawyer>(l => l.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(l => l.Position)
               .IsRequired()
               .HasConversion<string>()
               .HasMaxLength(50);

        builder.Property(l => l.OABNumber)
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(l => l.OABState)
               .IsRequired()
               .HasMaxLength(2);

        builder.Property(l => l.Biography)
            .HasMaxLength(500);

        builder.Property(l => l.IsActive)
               .IsRequired()
               .HasDefaultValue(true);

        builder.Property(l => l.CreatedAt)
            .HasConversion(
                v => v,
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        builder.Property(l => l.UpdatedAt)
            .HasConversion(
                v => v,
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
    }
}
