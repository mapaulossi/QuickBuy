using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using QuickBuy.Domain.Entities;
using QuickBuy.Domain.ObjectOfValue;
using QuickBuy.Repository.Config;

namespace QuickBuy.Repository.Context
{
    public class QuickBuyContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }

        public QuickBuyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Classes de mapeamento

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            //Carga inicial PaymentMethod
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod()
                {
                    Id = 1,
                    Name = "Billet",
                    Description = "Payment Method is Billet"
                },
                new PaymentMethod()
                {
                    Id = 2,
                    Name = "CreditCard",
                    Description = "Payment Method is CreditCard"
                },
                new PaymentMethod() {
                    Id = 3,
                    Name = "Deposit",
                    Description = "Payment Method is Deposit"
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
