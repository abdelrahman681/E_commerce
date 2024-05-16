using E_Commerce.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.DataContext
{
    public static class E_commIdentityDataContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "AbdulrahmanSalah",
                    DisplayName= "Abdulrahman Salah",
                    Email = "Abdulrahman@gmail.com",
                    Address = new Address
                    {
                        City="Cairo",
                        State="Dokki",
                        Country="Egypt",
                        Street="El152",
                        PostalCode="9522014"
                    }
                };
                await userManager.CreateAsync(user, "Password145656@");
            }
        }
    }

    
}
