using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Core.Entities;

namespace MIS.Infrastructure.Persistence.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.ExternalId).HasMaxLength(64);

        builder.HasIndex(d => d.ExternalId)
            .IsUnique()
            .HasFilter("\"ExternalId\" IS NOT NULL");

        builder.Property(d => d.LastName).HasMaxLength(100);
        builder.Property(d => d.FirstName).HasMaxLength(100);
        builder.Property(d => d.MiddleName).HasMaxLength(100);

        builder.Property(d => d.Room).HasMaxLength(10);

        builder.HasIndex(d => d.Specialty);
    }
}