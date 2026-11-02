using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Core.Entities;

namespace MIS.Infrastructure.Persistence.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ExternalId).HasMaxLength(64);

        // Уникальность только среди заполненных: у локально заведённых пациентов
        // внешнего идентификатора ещё нет, и они не должны конфликтовать по NULL.
        builder.HasIndex(p => p.ExternalId)
            .IsUnique()
            .HasFilter("\"ExternalId\" IS NOT NULL");

        builder.Property(p => p.LastName).HasMaxLength(100);
        builder.Property(p => p.FirstName).HasMaxLength(100);
        builder.Property(p => p.MiddleName).HasMaxLength(100);

        builder.Property(p => p.Snils).HasMaxLength(14);
        builder.Property(p => p.OmsPolicy).HasMaxLength(16);
        builder.Property(p => p.Phone).HasMaxLength(20);
    }
}