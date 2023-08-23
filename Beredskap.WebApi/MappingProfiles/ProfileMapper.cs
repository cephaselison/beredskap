using Beredskap.DTOs.TenantDTOs;
using Beredskap.DTOs.VenueDTOs;
using Beredskap.Domain.Entities;
using Beredskap.DTOs.IncidentDTOs;
using AutoMapper;

namespace Beredskap.WebApi.MappingProfiles
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<CreateVenueRequest, VenueEntity>();
            CreateMap<UpdateVenueRequest, VenueEntity>();
            CreateMap<UpdateTenantRequest, TenantEntity>();
            CreateMap<TenantDTO, TenantEntity>().ReverseMap();
            CreateMap<IncidentDTO, Incident>().ReverseMap();
        }
    }
}
