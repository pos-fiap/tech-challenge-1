using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RCLocacoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Data.Entity.ProductMap
{
    public class ProductMap : IEntityTypeConfiguration<Domain.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("varchar(100)");
            builder.Property(p => p.Description).HasColumnType("varchar(250)");
            builder.Property(p => p.RentPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.ReplacementCost).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.Inactive).HasColumnType("bit").IsRequired();
            builder.Property(p => p.Picture).HasColumnType("varchar(MAX)");

        }
    }
}
