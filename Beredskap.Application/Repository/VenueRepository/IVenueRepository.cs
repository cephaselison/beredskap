using Beredskap.Application.EFRepository;
using Beredskap.DTOs.ResponseDTOs;
using Beredskap.DTOs.VenueDTOs;
using Beredskap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beredskap.Application.Repository.VenueRepository
{
    public interface IVenueRepository:IRepository<VenueEntity>
    {
        bool CheckExisting(string key);
        Task<Guid> SaveVenueAsync(CreateVenueRequest modal);
        Task<Guid> UpdateVenueAsync(UpdateVenueRequest modal, Guid id);
        Task<ResponseDTO> DeleteVenueAsync(Guid Id);
        IQueryable<VenueEntity> GetAllVenues();
    }
}
