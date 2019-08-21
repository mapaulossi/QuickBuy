﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Domain.Entities;

namespace QuickBuy.Repository.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.DateOrder)
                .IsRequired();

            builder
                .Property(o => o.DeliveryPredictionDate)
                .IsRequired();

            builder
                .Property(o => o.CEP)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(o => o.City)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(o => o.State)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(o => o.FullAddress)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(o => o.AddressNumber)
                .IsRequired();

            builder
                .HasOne(o => o.PaymentMethod);
        }
    }
}
