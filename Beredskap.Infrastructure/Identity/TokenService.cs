using Beredskap.DTOs.AuthDTOs;
using Beredskap.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Beredskap.DTOs.VenueDTOs;
using Beredskap.Infrastructure.Multitenancy;


namespace Beredskap.Infrastructure.Identity
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ITenantService _tenantService;

        public TokenService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<TokenResponse> GetTokenAsync(TokenRequest request)
        {
            //check tenant here
            //tenant key must be in header 
            var user = await _userManager.FindByEmailAsync(request.Email.Trim());
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim> {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("tenant", user.TenantId.ToString()),
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

                return (new TokenResponse
                {
                    User = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    Id = user.Id,
                });
            }
            throw new Exception();
            //return HttpStatusCode.Unauthorized;
        }
    }

}
