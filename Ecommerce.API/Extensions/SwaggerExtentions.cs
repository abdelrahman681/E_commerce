using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace E_commerce.API.Extensions
{
    public static class SwaggerExtentions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen(options =>
            //{
            //    //    var scheme = new OpenApiSecurityScheme
            //    //    {
            //    //        Description="******************",
            //    //        Name= "Authorization",
            //    //        In=ParameterLocation.Header,
            //    //        Type= SecuritySchemeType.ApiKey
            //    //    };
            //    //    options.AddSecurityDefinition("Bearer",scheme);
            //    //    options.OperationFilter<SecurityRequirementsOperationFilter>();
            //    //});

            //});
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });
            return services;
        }
    }
}

