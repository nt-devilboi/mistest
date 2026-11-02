using Microsoft.AspNetCore.Mvc;
using MIS.Api.Dtos;
using MIS.Core.Abstractions;

namespace MIS.Api.Controllers;

[ApiController]
[Route("api/diseases")]
public class DiseasesController(IDiseaseRepository diseases, ILogger<DiseasesController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<DiseaseDto>>> GetAll(CancellationToken cancellationToken)
    {
        var found = await diseases.GetAllAsync(cancellationToken);

        logger.LogInformation("Возвращено болезней: {Count}", found.Count);

        return Ok(found.Select(d => new DiseaseDto(d.Id, d.IcdCode, d.Name)));
    }
}
