using E_Commerce.Domain.Entity.Identity;
using E_Commerce.Repositry.DataContext;
using E_Commerce.Services.DataContext;
using Ecommerce.API;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.API.Extensions
{
    public static class DbIntializer
    {
        public static async Task Initialize(WebApplication app)
        {
            using (var scope = app.Services.CreateAsyncScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactor = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = service.GetRequiredService<E_CommerceDataContext>();
                    var user = service.GetRequiredService<UserManager<ApplicationUser>>();
                    if ((await context.Database.GetPendingMigrationsAsync()).Any())
                        await context.Database.MigrateAsync();

                    await DataContextSeed.SeedData(context);
                    await E_commIdentityDataContextSeed.SeedUsersAsync(user);
                }
                catch (Exception ex)
                {

                    var logger = loggerFactor.CreateLogger<Program>();
                    logger.LogError(ex.Message);
                }
            }
        }

    }
}
