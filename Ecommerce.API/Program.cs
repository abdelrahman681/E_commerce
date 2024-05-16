using E_commerce.API.Errors;
using E_Commerce.Domain.Interfaces.Repositry;
using E_Commerce.Domain.Interfaces.Services;
using E_Commerce.Repositry.DataContext;
using E_Commerce.Repositry.Repositry;
using E_Commerce.Services;
using E_Commerce.Services.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using StackExchange.Redis;
using Microsoft.AspNetCore.Identity;
using E_Commerce.Domain.Entity.Identity;
using E_commerce.API.Extensions;
using Microsoft.Extensions.Configuration;


namespace Ecommerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSwaggerServices();
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.IdentityServices(builder.Configuration);
            
            #endregion
            var app = builder.Build();
            await DbIntializer.Initialize(app);
            #region PipeLine
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<CoustomExceptionHandler>();
            app.UseStaticFiles();
            app.MapControllers();

            app.Run(); 
            #endregion
        }



    }
}
