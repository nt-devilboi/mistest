using MIS.Core.Entities;
using MIS.Core.Enums;

namespace MIS.Core.Abstractions;

public interface IDoctorRepository
{
    /// <summary>Врачи, отфильтрованные по специальности. null — без фильтра.</summary>
    Task<IReadOnlyList<Doctor>> GetAsync(Specialty? specialty, CancellationToken cancellationToken);
}
