using MIS.Core.Enums;

namespace MIS.Api.Dtos;

public record PatientListItemDto(
    Guid Id,
    string LastName,
    string FirstName,
    string? MiddleName,
    DateOnly BirthDate,
    Sex Sex);