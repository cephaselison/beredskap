using Beredskap.DTOs.AuthDTOs;
using Beredskap.DTOs.TenantDTOs;
using Beredskap.Enums;
using Beredskap.Infrastructure.Multitenancy;
using Beredskap.Infrastructure.Persistence;
using Beredskap.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cors;


//It should only have two endpoints, get token and refresh token
//registration to be done in Identity Controller (by admins only, no open registration)
namespace Beredskap.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowReactApp")]
    public class TokensController : ControllerBase
    {
      
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITenantService _tenantService;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public TokensController(ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ITenantService tenantService,
            IConfiguration configuration
            )
        {
            _dbContext = dbContext;
            _userManager=userManager;   
            _signInManager=signInManager;
            _roleManager=roleManager;
            _tenantService = tenantService;
            _configuration =configuration;
        }


        [AllowAnonymous]
        [HttpPost]
        //api/tokens
        public async Task<IActionResult> Login([FromHeader]string tenant,[FromBody] TokenRequest request)
        {
            //var tenant = _tenantService.GetCurrentTenant();
            //check tenant here
            //tenant key must be in header 
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            // if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var isNotAdmin = Guid.TryParse(user.TenantId, out Guid tenantId); 
                if (roles.Any(x => x != UserRoles.SuperAdmin) && isNotAdmin && !_dbContext.Tenant.Any(x => x.Id == tenantId)) return Unauthorized();
                
                
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim> {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                //new Claim("tenant", user.TenantId),
                new Claim("tenant", user.TenantId),

                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var key = Encoding.ASCII.GetBytes("My_Secret_Key_BeredskapProject");
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(2),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    );
                return Ok(new
                {
                    user.Id,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    User = user.Email,
                    TenantId = tenantId,
                    Roles = roles,
                });
            }
            return Unauthorized();
        }

    }
}
