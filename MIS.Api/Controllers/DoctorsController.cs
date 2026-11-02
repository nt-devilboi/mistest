using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIS.Api.Dtos;
using MIS.Core.Enums;
using MIS.Infrastructure.Persistence;

namespace MIS.Api.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorsController(MisDbContext db, ILogger<DoctorsController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<DoctorDto>>> Get(
        [FromQuery] Specialty? specialty,
        CancellationToken cancellationToken)
    {
        var query = db.Doctors.AsNoTracking();

        if (specialty is not null)
        {
            query = query.Where(d => d.Specialty == specialty);
        }

        var doctors = await query
            .OrderBy(d => d.Specialty)
            .ThenBy(d => d.LastName)
            .Select(d => new DoctorDto(
                d.Id,
                d.LastName,
                d.FirstName,
                d.MiddleName,
                d.Specialty,
                d.Room))
            .ToListAsync(cancellationToken);

        logger.LogInformation(
            "Возвращено врачей: {Count}, фильтр по специальности: {Specialty}",
            doctors.Count,
            specialty?.ToString() ?? "без фильтра");

        return Ok(doctors);
    }
}