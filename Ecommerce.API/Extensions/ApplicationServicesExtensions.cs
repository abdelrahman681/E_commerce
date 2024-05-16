using E_Commerce.Domain.Interfaces.Repositry;
using E_Commerce.Domain.Interfaces.Services;
using E_Commerce.Repositry.DataContext;
using E_Commerce.Repositry.Repositry;
using E_Commerce.Services.DataContext;
using E_Commerce.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using E_commerce.API.Errors;

namespace E_commerce.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<E_CommerceDataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLConnection"));
            });
            services.AddSingleton<IConnectionMultiplexer>(opt =>
            {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("RedisConnection"));
                return ConnectionMultiplexer.Connect(config);

            });
            services.AddDbContext<E_commIdentityDataContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("IdentitySQLConnection"));
            });
            services.Configure<ApiBehaviorOptions>(op =>
            {
                op.InvalidModelStateResponseFactory = con =>
                {
                    var errors = con.ModelState.Where(x => x.Value!.Errors.Any()).SelectMany(x => x.Value.Errors)
                    .Select(e => e.ErrorMessage);

                    return new BadRequestObjectResult(new APIValidationErrorResponse() { Errors = errors });
                };
            });
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderServices>();
            services.AddScoped<IBasketServices, BasketServices>();
            services.AddScoped<IBasketItemRepositpry, BasketItemRepositpry>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICashService, CashService>();
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPayService, PayService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
