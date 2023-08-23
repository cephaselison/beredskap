using Beredskap.Domain.Entities;
using Beredskap.DTOs.TenantDTOs;
using Beredskap.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Beredskap.Application.Services.TenantService;

public class TenantService: ITenantService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public TenantService(ApplicationDbContext dbContext, IMapper mapper)
    {
        //_venueRepository = venueRepository;
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<List<TenantDTO>> GetTenants()
    {
        var tenants = await _dbContext.Tenant.OrderBy(x => x.Key).ToListAsync();
        return _mapper.Map<List<TenantDTO>>(tenants);
    }
    
    public async Task<TenantDTO> GetTenant(Guid id)
    {
        var tenants = await _dbContext.Tenant.SingleOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<TenantDTO>(tenants);
    }


    public async Task<TenantDTO> AddTenant(CreateTenantRequest model)
    {
        var tenant = new TenantDTO
        {
            Id = Guid.NewGuid().ToString(),
            Key = model.Key,
            IsActive = true
        };

        _dbContext.Tenant.Add(_mapper.Map<TenantEntity>(tenant));
        await _dbContext.SaveChangesAsync();

        return tenant;
    }
}