using Microsoft.EntityFrameworkCore;
using MIS.Core.Abstractions;
using MIS.Core.Entities;
using MIS.Core.Enums;

namespace MIS.Infrastructure.Persistence.Repositories;

public class DoctorRepository(MisDbContext db) : IDoctorRepository
{
    public async Task<IReadOnlyList<Doctor>> GetAsync(Specialty? specialty, CancellationToken cancellationToken)
    {
        var query = db.Doctors.AsNoTracking();

        if (specialty is not null)
        {
            query = query.Where(d => d.Specialty == specialty);
        }

        return await query
            .OrderBy(d => d.Specialty)
            .ThenBy(d => d.LastName)
            .ToListAsync(cancellationToken);
    }
}
