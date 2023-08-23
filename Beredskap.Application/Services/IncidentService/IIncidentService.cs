using Beredskap.DTOs.IncidentDTOs;

namespace Beredskap.Application.Services.IncidentService;

public interface IIncidentService
{
    Task<List<IncidentDTO>> GetIncidents();
    Task<IncidentDTO> GetIncident(Guid id);
    Task<IncidentDTO> AddOrUpdateIncident(IncidentDTO model);
}