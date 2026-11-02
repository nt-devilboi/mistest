using Microsoft.EntityFrameworkCore;
using MIS.Core.Entities;

namespace MIS.Infrastructure.Persistence;

public class MisDbContext(DbContextOptions<MisDbContext> options) : DbContext(options)
{
    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<Disease> Diseases => Set<Disease>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MisDbContext).Assembly);
    }
}
