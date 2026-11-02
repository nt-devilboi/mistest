using MIS.Core.Enums;

namespace MIS.Api.Dtos;

public record DoctorDto(
    Guid Id,
    string LastName,
    string FirstName,
    string? MiddleName,
    Specialty Specialty,
    string? Room);
