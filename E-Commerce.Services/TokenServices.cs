using E_Commerce.Domain.Entity.Identity;
using E_Commerce.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class TokenServices : ITokenServices
    {

        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public  string GenerateToken(ApplicationUser user)
        {
            var claime = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name,user.DisplayName),
            };

            var Key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
            var credential = new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(claime),
                Issuer= _configuration["Token:Issuer"],
                SigningCredentials = credential,
                Audience= _configuration["Token:MyAudience"],
                //IssuedAt=DateTime.UtcNow,
                Expires=DateTime.UtcNow.AddYears(10),
                
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            //var roles=await _userManager.GetRolesAsync(user);
            //claime.AddRange(roles.Select(roles=>new Claim(ClaimTypes.Role, roles)));

            throw new NotImplementedException();
        }
    }
}
