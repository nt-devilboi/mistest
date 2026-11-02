using MIS.Core.Enums;

namespace MIS.Api.Dtos;

public record PatientDetailsDto(
    Guid Id,
    string? ExternalId,
    string LastName,
    string FirstName,
    string? MiddleName,
    DateOnly BirthDate,
    Sex Sex,
    string? Snils,
    string? OmsPolicy,
    string? Phone,
    IReadOnlyCollection<DiseaseDto> Diseases);
