using Beredskap.Domain.Entities;
using Beredskap.DTOs.ResponseDTOs;
using Beredskap.DTOs.TenantDTOs;
using Beredskap.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Beredskap.Infrastructure.Multitenancy
{
    public class TenantService : ITenantService
    {

        // private readonly ITenantRepository _tenantRepository;
        // private readonly IRepository<TenantEntity, long> _tenantRepo;
        private TenantDTO _currentTenant;
        //private HttpContext _httpContext;
        private readonly HttpContext _httpContext;
        
        public TenantService(IHttpContextAccessor httpContextAccessor = null)
        {
            //_tenantManagementDbContext = tenantManagementDbContext;

            //so everytime this instantiates, looks at the header or auth
            _httpContext = httpContextAccessor?.HttpContext;
            if (_httpContext != null)
            {
                _httpContext.Request.Headers.TryGetValue("tenant", out var tenantFromHeader);
                var requestPath = _httpContext.Request.Path.ToString();
                var isLogin = requestPath.Contains("/api/tokens") || requestPath.Contains("/api/tenants");

                //string tenantId = TenantResolver.Resolver(_httpContext);
                if (!string.IsNullOrEmpty(tenantFromHeader) || isLogin)
                {
                    SetCurrentTenant(isLogin ? String.Empty : tenantFromHeader);
                }
                else
                {
                    throw new Exception("Invalid Tenant!");
                }
            }

        }

        //public TenantService(ITenantRepository tenantRepository)
        //{
        //    _tenantRepository = tenantRepository;
        //}

        //public bool CheckExisting(string key)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<TenantDTO> GetAllTenants()
        //{
        //    return _tenantRepository.GetAllTenants().Select(x => new TenantDTO
        //    {
        //        Id = x.Id.ToString(),
        //        Key = x.Key,
        //    }).ToList();
        //}

        // public async Task<bool> SaveTenant(CreateTenantRequest modal)
        // {
        //     return await _tenantRepository.SaveTenant(modal);
        // }

        //public async Task<Guid> UpdateTenantAsync(UpdateTenantRequest modal, Guid id)
        //{
        //    return await _tenantRepository.UpdateTenantAsync(modal, id);
        //}

        //public async Task<ResponseDTO> RemoveTenant(Guid Id)
        //{
        //    var singleTenant = await Get(Id);
        //    if (singleTenant != null)
        //    {
        //        singleTenant.IsDeleted = true;
        //        singleTenant.DeletedOn = DateTime.UtcNow;
        //        var userId = httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //        singleTenant.DeletedBy = !string.IsNullOrEmpty(userId) ? Guid.Parse(userId) : new Guid();
        //        //Updating
        //        await Change(singleTenant);

        //        return new ResponseDTO() { IsSuccessful = true, Response = "Deleted Successfully", StatusCode = 1 };
        //    }
        //    return new ResponseDTO() { IsSuccessful = false, Response = "Deleted Failed", StatusCode = 0 };
        //}
        public TenantDTO GetCurrentTenant()
        {
            return _currentTenant;
        }

        public bool CheckExisting(string key)
        {
            throw new NotImplementedException();
        }

        public void SetCurrentTenant(string tenant)
        {
            if (_currentTenant != null)
            {
                throw new Exception("Method reserved for in-scope initialization");
            }

            var tenantDto = new TenantDTO();
            //var tenantInfo = _tenantManagementDbContext.Tenant.Where(x=>x.Key == tenant).FirstOrDefault();
            tenantDto.Id = tenant;
            //if (tenantInfo != null)
            //{
            //    tenantDto.Id = tenantInfo.Id.ToString();
            //    tenantDto.Key = tenantInfo.Key;

            //}

            if (tenantDto == null)
            {
                throw new Exception("Tenant Invalid");
            }



            _currentTenant = tenantDto;

        }

    }
}