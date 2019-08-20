using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Domain.Entities;

namespace QuickBuy.Repository.Config
{
    class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.ProductId)
                .IsRequired();

            builder
                .Property(o => o.Quantity)
                .IsRequired();

        }
    }
}
