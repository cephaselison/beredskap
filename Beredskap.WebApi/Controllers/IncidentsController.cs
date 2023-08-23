using Beredskap.Application.Services.IncidentService;
using Beredskap.DTOs.IncidentDTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Beredskap.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors("AllowReactApp")]
public class IncidentsController : ControllerBase
{
    private readonly IIncidentService _incidentService;

    public IncidentsController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetIncidents()
    {
        var result = await _incidentService.GetIncidents();

        return Ok(result);
    }
    
    [HttpGet("api/incidents/{id}")]
    public async Task<IActionResult> GetIncident(Guid id)
    {
        var result = await _incidentService.GetIncident(id);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> AddOrUpdateIncident([FromBody] IncidentDTO model)
    {
        var result = await _incidentService.AddOrUpdateIncident(model);
        return Ok(result);
    }
}