using MIS.Core.Entities;

namespace MIS.Core.Abstractions;

public interface IDiseaseRepository
{
    Task<IReadOnlyList<Disease>> GetAllAsync(CancellationToken cancellationToken);
}
