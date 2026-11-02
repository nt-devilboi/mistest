using MIS.Core.Entities;

namespace MIS.Core.Abstractions;

public interface IPatientRepository
{
    Task<IReadOnlyList<Patient>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>Пациент вместе с его болезнями, null если не найден.</summary>
    Task<Patient?> GetByIdWithDiseasesAsync(Guid id, CancellationToken cancellationToken);
}
