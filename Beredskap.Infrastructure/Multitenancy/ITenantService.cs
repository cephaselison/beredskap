using Beredskap.Domain.Entities;
using Beredskap.DTOs.ResponseDTOs;
using Beredskap.DTOs.TenantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beredskap.Infrastructure.Multitenancy
{
    public interface ITenantService
    {
        //List<TenantDTO> GetAllTenants();
        //bool CheckExisting(string key);
        // Task<bool> SaveTenant(CreateTenantRequest modal);
        //Task<Guid> UpdateTenantAsync(UpdateTenantRequest modal, Guid id);
        //Task<ResponseDTO> RemoveTenant(Guid Id);

        //GetTenantByKey
        public TenantDTO GetCurrentTenant();
        public bool CheckExisting(string key);
        public void SetCurrentTenant(string tenant);
    }
}
