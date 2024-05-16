using E_Commerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.DataConfigrition
{
    internal class ProductConfigrition : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasOne(product => product.ProductBrand).WithMany().HasForeignKey(p=>p.BrandId);
            builder.HasOne(product => product.ProductType).WithMany().HasForeignKey(p=>p.TypeId);


        }
    }
}
