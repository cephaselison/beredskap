using Beredskap.Application.Services.TenantService;
using Beredskap.DTOs.ResponseDTOs;
using Beredskap.DTOs.TenantDTOs;
using Beredskap.Enums;

using Beredskap.WebApi.Validators.Tenants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Beredskap.WebApi.Controllers
{
    // [Authorize(Roles = "SuperAdmin,admin")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowReactApp")]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<TenantDTO>> GetTenants()
        {
         
            var list = await _tenantService.GetTenants();
            return list;
        }


        [HttpPost]
        //POST
        //api/tenants
        public async Task<IActionResult> SaveTenant(CreateTenantRequest modal)
        {
            try
            {
                var result = await _tenantService.AddTenant(modal);
                return StatusCode((int)StatusCodeEnum.Ok, result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)StatusCodeEnum.Conflict, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenant(string id)
        {
            try
            {
                var result = await _tenantService.GetTenant(Guid.Parse(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateTenantRequest request, Guid id)
        {
            try
            {
                var validate = new UpdateTenantValidator();
                var validateResult = validate.Validate(request);
                if (validateResult.IsValid)
                {
                    return Ok();
                   // var result = await _tenantService.UpdateTenantAsync(request, id);
                    //return this.StatusCode((int)StatusCodeEnum.Ok, result);
                }
                else
                {
                    return BadRequest(validateResult.Errors);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode((int)StatusCodeEnum.Conflict, ex.Message);
            }
        }

        //[HttpDelete]
        //public async Task<ResponseDTO> DeleteTenant(Guid tenantId)
        //{
        //    return await _tenantService.RemoveTenant(tenantId);
        //}
    }
}
