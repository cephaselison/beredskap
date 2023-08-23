using Beredskap.Enums;

namespace Beredskap.DTOs.IncidentDTOs;

public class IncidentDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Location { get; set; } = String.Empty;
    public IncidentEnums IncidentStatus { get; set; }
}