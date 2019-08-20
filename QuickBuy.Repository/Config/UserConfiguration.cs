using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Domain.Entities;

namespace QuickBuy.Repository.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            //Builder ultiliza o padrão Fluent
            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(u => u.Name)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(400);

            builder
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(u => u.Orders) //Reforça a sobreposição do virtual
                .WithOne(o => o.User); //Ligado a um User por vez
        }
    }
}
