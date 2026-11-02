using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Core.Entities;

namespace MIS.Infrastructure.Persistence.Configurations;

public class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.IcdCode).HasMaxLength(10);
        builder.HasIndex(d => d.IcdCode).IsUnique();

        builder.Property(d => d.Name).HasMaxLength(200);
    }
}
