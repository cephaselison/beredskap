using Beredskap.Domain.Entities;
using Beredskap.DTOs.ResponseDTOs;
using Beredskap.DTOs.TenantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Beredskap.WebApi.Multitenancy
{
    public interface ITenantService
    {
        // List<TenantDTO> GetTenants();
        // bool CheckExisting(string key);
        //Task<bool> SaveTenant(CreateTenantRequest modal);
        //Task<Guid> UpdateTenantAsync(UpdateTenantRequest modal, Guid id);
        //Task<ResponseDTO> RemoveTenant(Guid Id);

        //GetTenantByKey
        public TenantDTO GetCurrentTenant();
        public void SetCurrentTenant(string tenant);
    }
}
