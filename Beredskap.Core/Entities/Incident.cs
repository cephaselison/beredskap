using System.ComponentModel.DataAnnotations;
using Beredskap.Domain.Entities.Common;
using Beredskap.Enums;

namespace Beredskap.Domain.Entities;

public class Incident : AuditableEntity, IMustHaveTenant
{
    [Encrypted]
    public string Name { get; set; }
    [Encrypted]
    public string Location { get; set; }
    public IncidentEnums IncidentStatus { get; set; }
    public string TenantId { get; set; }
}