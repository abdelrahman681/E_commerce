using E_Commerce.Domain.Entity.OrderEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.DataConfigrition
{
    public class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.OwnsOne(o => o.ShippingAddress, w => w.WithOwner());
            builder.Property(p => p.SubPrice).HasColumnType("decimal(18,4)");
        }
    }
}
