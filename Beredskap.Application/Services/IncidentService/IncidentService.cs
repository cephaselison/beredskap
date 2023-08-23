using System.Runtime.Intrinsics.Arm;
using Beredskap.Domain.Entities;
using Beredskap.DTOs.IncidentDTOs;
using Beredskap.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Beredskap.Application.Services.IncidentService;

public class IncidentService : IIncidentService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public IncidentService(ApplicationDbContext dbContext, IMapper mapper)
    {
        //_venueRepository = venueRepository;
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<List<IncidentDTO>> GetIncidents()
    {
        try
        {
            var test = _dbContext.Encrypt("Brann");
            var incidents = await _dbContext.Incident.ToListAsync();
            var result = _mapper.Map<List<IncidentDTO>>(incidents);
            
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
      
    }
    
    public async Task<IncidentDTO> GetIncident(Guid id)
    {
        
        var incident = await _dbContext.Incident.SingleOrDefaultAsync(x => x.Id == id);
        var result = _mapper.Map<IncidentDTO>(incident);

        return result;
    }

    public async Task<IncidentDTO> AddOrUpdateIncident(IncidentDTO model)
    {
        try
        {
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
                var toBeSaved = _mapper.Map<Incident>(model);
                _dbContext.Incident.Add(toBeSaved);
            }
            else
            {
                var existing = await _dbContext.Incident.SingleOrDefaultAsync(x => x.Id == model.Id);
                if (existing == null) throw new Exception("Incident not found");
                _mapper.Map(model, existing);
                _dbContext.Entry(existing).State = EntityState.Modified;
            }

            await _dbContext.SaveChangesAsync();
            return model;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
      
    }
}