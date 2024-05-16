using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Entity.OrderEntity;
using E_Commerce.Services.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.DataContext
{
    public static class DataContextSeed
    {
        public static async Task SeedData(E_CommerceDataContext context)
        {
            if (!context.Set<ProductBrand>().Any())
            {
                // Read File
                var BrandData = await File.ReadAllTextAsync(@"..\E-Commerce.Repositry\DataContext\DataSeeding\brands.json");

                // Covert Data int C# objec

                var Brand = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);

                //insert Data into DataBase

                if (Brand is not null && Brand.Any())
                {
                    await context.Set<ProductBrand>().AddRangeAsync(Brand);
                    await context.SaveChangesAsync();
                }
            }


            if (!context.Set<ProductType>().Any())
            {
                var TypeData = await File.ReadAllTextAsync(@"..\E-Commerce.Repositry\DataContext\DataSeeding\types.json");

                var Type = JsonSerializer.Deserialize<List<ProductType>>(TypeData);

                if (Type is not null && Type.Any())
                {
                    await context.Set<ProductType>().AddRangeAsync(Type);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<Products>().Any())
            {
                // Read File
                var ProductData = await File.ReadAllTextAsync(@"..\E-Commerce.Repositry\DataContext\DataSeeding\products.json");

                // Covert Data int C# objec

                var product = JsonSerializer.Deserialize<List<Products>>(ProductData);

                //insert Data into DataBase

                if (product is not null && product.Any())
                {
                    await context.Set<Products>().AddRangeAsync(product);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<DeliveryMethod>().Any())
            {
                var productdata = await File.ReadAllTextAsync(@"..\E-Commerce.Repositry\DataContext\DataSeeding\delivery.json");
                var delivery=JsonSerializer.Deserialize<List<DeliveryMethod>>(productdata);
                if(delivery is not null && delivery.Any())
                {
                    await context.Set<DeliveryMethod>().AddRangeAsync(delivery);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
