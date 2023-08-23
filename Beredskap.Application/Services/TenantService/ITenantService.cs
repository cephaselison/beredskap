using Beredskap.Domain.Entities;
using Beredskap.DTOs.TenantDTOs;

namespace Beredskap.Application.Services.TenantService;

public interface ITenantService
{
    public Task<List<TenantDTO>> GetTenants();
    public Task<TenantDTO> AddTenant(CreateTenantRequest name);
    public Task<TenantDTO> GetTenant(Guid id);
}