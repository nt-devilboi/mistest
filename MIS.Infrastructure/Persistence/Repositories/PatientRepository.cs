using Microsoft.EntityFrameworkCore;
using MIS.Core.Abstractions;
using MIS.Core.Entities;

namespace MIS.Infrastructure.Persistence.Repositories;

public class PatientRepository(MisDbContext db) : IPatientRepository
{
    public async Task<IReadOnlyList<Patient>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await db.Patients
            .AsNoTracking()
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .ToListAsync(cancellationToken);
    }

    public async Task<Patient?> GetByIdWithDiseasesAsync(Guid id, CancellationToken cancellationToken)
    {
        return await db.Patients
            .AsNoTracking()
            .Include(p => p.Diseases)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}
