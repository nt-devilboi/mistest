using MIS.Core.Enums;

namespace MIS.Core.Entities;

public class Doctor
{
    public Guid Id { get; set; }

    /// <summary>Идентификатор врача во внешней МИС.</summary>
    public string? ExternalId { get; set; }

    public required string LastName { get; set; }

    public required string FirstName { get; set; }

    public string? MiddleName { get; set; }

    public Specialty Specialty { get; set; }

    /// <summary>Кабинет приёма.</summary>
    public string? Room { get; set; }
}
