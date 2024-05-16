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
    public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(x => x.productItemOrder, w => w.WithOwner());
            builder.Property(p => p.Price).HasColumnType("decimal(18,4)");
        }
    }
}
