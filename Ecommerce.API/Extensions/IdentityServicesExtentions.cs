using E_Commerce.Domain.Entity.Identity;
using E_Commerce.Repositry.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_commerce.API.Extensions
{
    public static class IdentityServicesExtentions
    {
        public static IServiceCollection IdentityServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<E_commIdentityDataContext>()
            .AddSignInManager<SignInManager<ApplicationUser>>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                    ValidateAudience = true,
                    ValidAudience = configuration["Token:MyAudience"],
                    ValidateLifetime = true, 
                };
            });
            return services;
        }
    }
}
