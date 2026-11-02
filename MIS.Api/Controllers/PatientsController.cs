using Microsoft.AspNetCore.Mvc;
using MIS.Api.Dtos;
using MIS.Core.Abstractions;

namespace MIS.Api.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController(IPatientRepository patients, ILogger<PatientsController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<PatientListItemDto>>> GetAll(CancellationToken cancellationToken)
    {
        var found = await patients.GetAllAsync(cancellationToken);

        logger.LogInformation("Возвращено пациентов: {Count}", found.Count);

        return Ok(found.Select(p => new PatientListItemDto(
            p.Id,
            p.LastName,
            p.FirstName,
            p.MiddleName,
            p.BirthDate,
            p.Sex)));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PatientDetailsDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var patient = await patients.GetByIdWithDiseasesAsync(id, cancellationToken);

        if (patient is null)
        {
            logger.LogWarning("Пациент {PatientId} не найден", id);
            return NotFound();
        }

        return Ok(new PatientDetailsDto(
            patient.Id,
            patient.ExternalId,
            patient.LastName,
            patient.FirstName,
            patient.MiddleName,
            patient.BirthDate,
            patient.Sex,
            patient.Snils,
            patient.OmsPolicy,
            patient.Phone,
            patient.Diseases
                .OrderBy(d => d.IcdCode)
                .Select(d => new DiseaseDto(d.Id, d.IcdCode, d.Name))
                .ToList()));
    }
}
