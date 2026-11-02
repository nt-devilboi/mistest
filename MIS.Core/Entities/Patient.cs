using MIS.Core.Enums;

namespace MIS.Core.Entities;

public class Patient
{
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор пациента во внешней МИС. Строка, потому что формат чужой
    /// системы не контролируется; null, пока запись не сопоставлена.
    /// </summary>
    public string? ExternalId { get; set; }

    public required string LastName { get; set; }

    public required string FirstName { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly BirthDate { get; set; }

    public Sex Sex { get; set; }

    /// <summary>Ключ сопоставления пациента при обмене с ЕГИСЗ.</summary>
    public string? Snils { get; set; }

    /// <summary>Единый номер полиса ОМС, по нему выставляется счёт в страховую.</summary>
    public string? OmsPolicy { get; set; }

    public string? Phone { get; set; }

    public ICollection<Disease> Diseases { get; set; } = new List<Disease>();
}
