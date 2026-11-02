using Microsoft.EntityFrameworkCore;
using MIS.Core.Abstractions;
using MIS.Core.Entities;

namespace MIS.Infrastructure.Persistence.Repositories;

public class DiseaseRepository(MisDbContext db) : IDiseaseRepository
{
    public async Task<IReadOnlyList<Disease>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await db.Diseases
            .AsNoTracking()
            .OrderBy(d => d.IcdCode)
            .ToListAsync(cancellationToken);
    }
}
